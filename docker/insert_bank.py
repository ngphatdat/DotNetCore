import pyodbc
from faker import Faker

# Define the connection parameters
server_name = "localhost,1433"
database_name = "stock_app"
username = "sa"
password = "MyStrongPass123"
driver = "{ODBC Driver 18 for SQL Server}"
# Connect to the SQL Server database
conn = pyodbc.connect(f"DRIVER={driver};SERVER={server_name};DATABASE={database_name};UID={username};PWD={password};TrustServerCertificate=yes;")
# Create a cursor object
cursor = conn.cursor()
# Create an instance of the Faker class 
fake = Faker()
user_ids = [i for i in range(1, 5)]
# Generate and insert 20 random rows of data into the "linked_bank_accounts" table
for _ in range(20):
    user_id = fake.random_element(elements=user_ids)
    bank_name = fake.company()+ "Bank"
    account_number = fake.unique.random_number(digits=10)
    account_holder_name = fake.name()
    account_type = fake.random_element(elements=["Checking", "Savings"])
    created_at = fake.date_time_this_year()

    # Insert the data into the "linked_bank_accounts" table
    cursor.execute("INSERT INTO linked_bank_accounts (user_id, bank_name, account_number, account_holder_name, account_type, created_at) VALUES (?, ?, ?, ?, ?, ?)", user_id, bank_name, account_number, account_holder_name, account_type, created_at)

# Commit the changes and close the connection
conn.commit()
conn.close()
# Generate and insert 20 random rows of data into the "etfs" table

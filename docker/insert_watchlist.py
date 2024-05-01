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
stock_ids = [i for i in range(1002, 1101)] 
user_ids = [i for i in range(1, 5)]
# Generate and insert 20 random rows of data into the "watch_list" table
for _ in range(20):
    user_id = fake.random_element(elements=user_ids)
    stock_id = fake.random_element(elements=stock_ids)

    # Insert the data into the "watch_list" table
    cursor.execute("INSERT INTO watch_list (user_id, stock_id) VALUES (?, ?)", user_id, stock_id)

# Commit the changes and close the connection
conn.commit()
conn.close()
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

# Generate and insert 100 random rows of data into the "etfs" table
for _ in range(10):
    name = fake.company()
    symbol = fake.random_element(elements=('AAPL', 'GOOGL', 'MSFT', 'AMZN', 'FB', 'TSLA', 'NVDA', 'INTC', 'AMD', 'CSCO', 'QCOM', 'IBM', 'ORCL', 'ADBE', 'CRM', 'PYPL', 'NFLX', 'AVGO', 'TXN', 'ACN', 'MU', 'ADP', 'INTU', 'AMAT', 'ADI', 'LRCX'))    
    management_company = fake.company()
    inception_date = fake.date_between(start_date='-10y', end_date='today')
    # Insert the data into the "etfs" table
    cursor.execute("INSERT INTO etfs (name, symbol, management_company, inception_date) VALUES (?, ?, ?, ?)", name, symbol, management_company, inception_date)
# Commit the changes and close the connection
conn.commit()
conn.close()
import random
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
etf_ids = [i for i in range(27, 126)]

# Create a list of tuples containing the stock data
# Generate and insert 100 random rows of data into the "etf_holdings" table
for _ in range(100):
    etf_id = fake.random_element(elements=etf_ids)
    stock_id = fake.random_element(elements=stock_ids)
    weight = round(random.uniform(0.01, 0.5), 4)
    shares_held = round (random. uniform(100, 1000), 4)
    # Insert the data into the "etf_holdings" table
    cursor.execute("INSERT INTO etf_holdings (etf_id, stock_id, weight, shares_held) VALUES (?, ?, ?, ?)", etf_id, stock_id, weight, shares_held)
# Commit the changes and close the connection
conn.commit()
conn.close()
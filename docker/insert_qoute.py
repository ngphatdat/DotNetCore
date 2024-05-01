import random
from time import sleep
import pyodbc
from faker import Faker
import datetime

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

# Create a Faker instance
fake = Faker()

# Define the start time
start_time = datetime.datetime.now()
stock_ids = [i for i in range(1002, 1101)] 
# Generate and insert 1000 records
while True:
    # Generate fake data
    stock_id = fake.random_element(elements=stock_ids)
    price = round (random. uniform(1, 100), 2)
    change = round (random. uniform(-10, 10), 2)
    percent_change = round (change / price * 100, 2)
    volume = random. randint (1000, 1000000)
    time_stamp = timenow = datetime.datetime.now();
    # Insert the data into the qoutes table
    cursor.execute("""
        INSERT INTO dbo.qoutes (stock_id, price, change, precent_change, volume, time_stamp)
        VALUES (?, ?, ?, ?, ?, ?)
    """, stock_id, price, change, percent_change, volume, time_stamp)
    sleep(10)
# Commit the transaction
conn.commit()
conn.close()
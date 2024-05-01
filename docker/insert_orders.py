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
user_ids = [i for i in range(1, 5)]
# Generate and insert 20 random rows of data into the "orders" table
for _ in range(40):
    user_id = fake.random_element(elements=user_ids)
    stock_id = fake.random_element(elements=stock_ids)
    order_type = fake.random_element(elements=["Market", "Limit", "Stop"])
    quantity = fake.random_int(min=1, max=100)
    direction = fake.random_element(elements=["Buy", "Sell"])
    price = round(random.uniform(1, 100),2)
    status = fake.random_element(elements=["Cancelled", "Executed", "Pending"])
    order_date = fake.date_time_this_year()

    # Insert the data into the "orders" table
    cursor.execute("INSERT INTO orders (user_id, stock_id, order_type, quantity, direction, price, status, order_date) VALUES (?, ?, ?, ?, ?, ?, ?, ?)", user_id, stock_id, order_type, quantity, direction, price, status, order_date)
    # Print the inserted data
    print(f"Inserted data: user_id={user_id}, stock_id={stock_id}, order_type={order_type}, quantity={quantity}, direction={direction}, price={price}, status={status}, order_date={order_date}")
# Commit the changes and close the connection
conn.commit()
conn.close()
import random
import string
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
# Tao danh sách các mã cô phiêu da duroc sû dung
used_symbols = set()
def generate_word(min_length=2, max_length=10):
    letters = string.ascii_uppercase
    word_length = random.randint(min_length, max_length)
    word = '.'.join(random.choice(letters) for i in range(word_length))
    return word
# Generate and insert 100 random rows of data into the "stock" table
for _ in range(100):
    name = fake.company()
    symbol = generate_word()
    company_name = fake.company()
    price = random.uniform(10, 100)
    quantity = random.randint(100, 1000)
    market_cap = random.randint(1000000, 1000000000)
    SECTORS = {"Thurc phâm": "Food", "Bât dông san": "Real estate",
               "Ngân hang":"Banking","Bán le": "Retail",
                "Công nghê": "Technology","Co khí": "Mechanical",
                "Chúng khoán": "Securities", 
                "Quy däu tu": "Investment fund"}
    # Các giá tri cho truòng industry và industry_en
    INDUSTRIES = {"sữa và sản phẩm sữa": "Dairy and dairy products",
            "Phát triển bất động san": "Real estate development",
            "Bán lẽ thực phâm": "Food retailing", "Ngân hàng thương mai": "Commercial banking",
            "Công nghê thông tin": "Information technology",
            "Co khí chế tao" : "Mechanical manufacturing",
            "Chứng khoán đầu tư": "Investment securities",
            "Quÿ đầu tư chứng khoán": "Securities investment fund"}
    sector = random.choice(list(SECTORS.keys()))
    industry = random.choice(list(INDUSTRIES.keys()))
    sector_en = SECTORS[sector]
    industry_en = INDUSTRIES[industry]
    STOCK_TYPES={"commom stock","preferred stock","treasury stock","restricted stock","unrestricted stock"}
    stock_type = fake.word()
    rank = random.randint(1, 100)
    rank_source = fake.word()
    created_at = fake.date_time_this_decade()
    update_at = fake.date_time_this_decade()
    # Insert the data into the "stock" table
    cursor.execute("INSERT INTO stock (name, symbol, company_name, price, quantity, market_cap, secror, inductry, secror_en, inductry_en, stock_type, rank, rank_source, created_at,updated_at) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", name, symbol, company_name, price, quantity, market_cap, sector, industry, sector_en, industry_en, stock_type, rank, rank_source, created_at,update_at)

# Commit the changes and close the connection
conn.commit()
conn.close()
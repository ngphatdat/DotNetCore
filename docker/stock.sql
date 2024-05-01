CREATE TABLE [dbo].[users] (
    [user_id]       INT            IDENTITY (1, 1) NOT NULL,
    [user_name]     NVARCHAR (200) NOT NULL,
    [email]         NVARCHAR (200) NOT NULL,
    [hash_password] NVARCHAR (200) NOT NULL,
    [created_at]    DATETIME       NOT NULL,
    [updated_at]    DATETIME       NOT NULL,
    [contry]        NVARCHAR (200) NOT NULL,
    [date_of_birth] DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([user_id] ASC)
);

GO
CREATE TABLE user_dvices (
  id INT PRIMARY KEY IDENTITY,
  user_id INT NOT NULL,
  device_id INT NOT NULL,
  created_at datetime NOT NULL,
  updated_at datetime NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(id)
) ;
CREATE TABLE [dbo].[stock] (
    [stock_id]           INT             IDENTITY (1, 1) NOT NULL,
    [name]         NVARCHAR (200)  DEFAULT ('') NOT NULL,
    [symbol]       NVARCHAR (200)  NOT NULL,
    [company_name] NVARCHAR (200)  NOT NULL,
    [price]        DECIMAL (18, 2) NOT NULL,
    [quantity]     INT             NOT NULL,
    [maket_cap]    DECIMAL (18, 2) NOT NULL,
    [secror]       NVARCHAR (200)  NOT NULL,
    [inductry]     NVARCHAR (200)  NOT NULL,
    [secror_en]    NVARCHAR (200)  NOT NULL,
    [inductry_en]  NVARCHAR (200)  NOT NULL,
    [stock_type]   NVARCHAR (200)  NOT NULL,
    [rank]        INT             CONSTRAINT [DEFAULT_stock_rannk] DEFAULT ((0)) NOT NULL,
    [rank_source]  NVARCHAR (200)  NOT NULL,
    [created_at]   DATETIME        NULL,
    [updated_at]   DATETIME        NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);


    GO
CREATE TABLE qoutes(
    id INT PRIMARY KEY IDENTITY ,
    stock_id INT NOT NULL,
    price DECIMAL(18,2) NOT NULL,
    change DECIMAL(18,2) NOT NULL,
    precent_change DECIMAL(18,2) NOT NULL,
    volume INT NOT NULL,
    time_stamp datetime NOT NULL,
    created_at datetime ,
    updated_at datetime ,
    FOREIGN KEY (stock_id) REFERENCES stock(id)
    ) ;
CREATE TABLE maket_indexies(
    id INT PRIMARY KEY IDENTITY ,
    name NVARCHAR(200) NOT NULL,
    symbol NVARCHAR(200) NOT NULL, 
    ) ;
    GO
CREATE TABLE index_coustituents(
    index_id INT NOT NULL,
    stock_id INT NOT NULL,
    FOREIGN KEY (index_id) REFERENCES maket_indexies(id),
    FOREIGN KEY (stock_id) REFERENCES stock(id)
    ) ;
CREATE TABLE devivaties(
    id INT PRIMARY KEY IDENTITY ,
    name NVARCHAR(200) NOT NULL,
    underlying_asset_id INT NOT NULL,
    countrue_size NVARCHAR(200) NOT NULL,
    expration_date datetime NOT NULL,
    strike_price DECIMAL(18,2) NOT NULL,
    last_price DECIMAL(18,2) NOT NULL,
    percent_price DECIMAL(18,2) NOT NULL,
    open_price INT NOT NULL,
    hight_price INT NOT NULL,
    low_price INT NOT NULL,
    open_interest INT NOT NULL,
    volume INT NOT NULL,
    time_stamp datetime NOT NULL,
    ) ;
    GO
CREATE TABLE covered_warrants(
    id INT PRIMARY KEY IDENTITY ,
    underlying_asset_id INT NOT NULL,
    issue_date datetime NOT NULL,
    expration_date datetime NOT NULL,
    warrant_type NVARCHAR(200) NOT NULL,
    strike_price DECIMAL(18,2) NOT NULL,
    time_stamp datetime NOT NULL,
    ) ;
CREATE TABLE etfs(  
    id INT PRIMARY KEY IDENTITY ,
    name NVARCHAR(200) NOT NULL,
    symbol NVARCHAR(200) NOT NULL,
    manegerment_company NVARCHAR(200) NOT NULL,
    inception_date datetime NOT NULL
);
GO
CREATE TABLE etf_holdings(
    etf_id INT NOT NULL,
    stock_id INT NOT NULL,
    weight DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (etf_id) REFERENCES etfs(id),
    FOREIGN KEY (stock_id) REFERENCES stock(id)
    ) ;
CREATE TABLE watch_list(
    user_id INT NOT NULL,
    stock_id INT NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(id),
    FOREIGN KEY (stock_id) REFERENCES stock(id)
    ) ;
    GO
CREATE TABLE orders(
    id INT PRIMARY KEY IDENTITY ,
    user_id INT NOT NULL,
    stock_id INT NOT NULL,
    order_type NVARCHAR(200) NOT NULL,
    quantity INT NOT NULL,
    direction NVARCHAR NOT NULL,
    price DECIMAL(18,2) NOT NULL,
    status NVARCHAR(200) NOT NULL,
    order_date datetime NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(id),
    FOREIGN KEY (stock_id) REFERENCES stock(id)
    ) ;
    GO
CREATE TABLE portfolio(
    id INT PRIMARY KEY IDENTITY ,
    user_id INT NOT NULL,
    stock_id INT NOT NULL,
    quantity INT NOT NULL,
    purchase_date datetime NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(id),
    FOREIGN KEY (stock_id) REFERENCES stock(id)
    ) ;
CREATE TABLE notifications(
    id INT PRIMARY KEY IDENTITY ,
    user_id INT NOT NULL,
    contnet NVARCHAR(200) NOT NULL,
    created_at datetime NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(id)
    ) ;

CREATE TABLE linked_bank_accounts(
    id INT PRIMARY KEY IDENTITY ,
    user_id INT NOT NULL,
    bank_name NVARCHAR(200) NOT NULL,
    account_number NVARCHAR(200) NOT NULL,
    account_holder_name NVARCHAR(200) NOT NULL,
    account_type NVARCHAR(200) NOT NULL,
    created_at datetime NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(id)
    ) ;

GO
CREATE TABLE transactions(
    id INT PRIMARY KEY IDENTITY ,
    user_id INT NOT NULL,
    stock_id INT NOT NULL,
    order_id INT NOT NULL,
    link_bank_account_id INT NOT NULL,
    quantity INT NOT NULL,
    price DECIMAL(18,2) NOT NULL,
    transaction_date datetime NOT NULL,
    FOREIGN KEY (user_id) REFERENCES users(id),
    FOREIGN KEY (stock_id) REFERENCES stock(id),
    FOREIGN KEY (order_id) REFERENCES orders(id),
    FOREIGN KEY (link_bank_account_id) REFERENCES linked_bank_accounts(id)
    ) ;
CREATE TABLE education_resource(
    id INT PRIMARY KEY IDENTITY ,
    title NVARCHAR(200) NOT NULL,
    content NVARCHAR(200) NOT NULL,
    category NVARCHAR(200) NOT NULL,
    created_at datetime NOT NULL
    ) ;
    GO
    CREATE PROCEDURE register_user
        @user_name NVARCHAR(200),
        @email NVARCHAR(200),
        @password NVARCHAR(200),
        @contry NVARCHAR(200),
        @date_of_birth datetime
    As
    BEGIN
        INSERT INTO users (user_name, email, hash_password, created_at, updated_at, contry, date_of_birth)
        VALUES (@user_name, @email, HASHBYTES('SHA2_256',@password), GETDATE(), GETDATE(), @contry, @date_of_birth)
        
    END
    GO
    CREATE PROCEDURE login_user
        @email NVARCHAR(200),
        @password NVARCHAR(200)
        
    As  
    BEGIN
        SET NOCOUNT ON;
    DECLARE @HashPassword VARBINARY (32)
    SET @HashPassword = HASHBYTES ('SHA2_256', @Password);
    BEGIN
    SELECT * FROM users WHERE Email IN
    (   SELECT email FROM users WHERE email = @Email AND hash_password = @HashPassword);
    END
    END
    GO
    EXEC register_user 'admin1', N'admin1@admin', 'admin', 'VN', '1990-01-01'
    EXEC register_user 'admin2', N'admin2@admin', 'admin', 'VN', '1990-01-01'
    EXEC register_user 'admin3', N'admin3@admin', 'admin', 'VN', '1990-01-01'
    EXEC register_user 'admin4', N'admin4@admin', 'admin', 'VN', '1990-01-01'
    EXEC login_user N'admin1@admin', 'admin'
    EXEC login_user N'admin2@admin', 'admin'
    
    INSERT INTO stock (name, symbol, company_name, price, quantity, maket_cap, secror, inductry, secror_en, inductry_en, stock_type, rannk, rank_source, created_at, updated_at)
    VALUES ('Vingroup', 'VIC', 'Vingroup', 100000, 100000, 100000, 'Real Estate', 'Real Estate', 'Real Estate', 'Real Estate', 'Common Stock', 1, 'Forbes', GETDATE(), GETDATE())
    SELECT * FROM stock
    INSERT INTO stock  (name, symbol, company_name, price, quantity, maket_cap, secror, inductry, secror_en, inductry_en, stock_type, rannk, rank_source, created_at, updated_at)
   -- VALUES ('Vinamilk', 'VNM', 'Vinamilk', 100000, 100000, 100000, 'Consumer Goods', 'Consumer Goods', 'Consumer Goods', 'Consumer Goods', 'Common Stock', 2, 'Forbes', GETDATE(), GETDATE())
   -- VALUES ('Viettel', 'VTL', 'Viettel', 100000, 100000, 100000, 'Telecommunication', 'Telecommunication', 'Telecommunication', 'Telecommunication', 'Common Stock', 3, 'Forbes', GETDATE(), GETDATE())
    VALUES ('Vietcombank', 'VCB', 'Vietcombank', 100000, 100000, 100000, 'Finance', 'Finance', 'Finance', 'Finance', 'Common Stock', 4, 'Forbes', GETDATE(), GETDATE())
    SELECT * FROM stock
    INSERT INTO qoutes (stock_id, price, change, precent_change, volume, time_stamp, created_at, updated_at)
    --VALUES (1, 100000, 1000, 1, 100000, GETDATE(), GETDATE(), GETDATE())
    --VALUES (2, 100000, 1000, 1, 100000, GETDATE(), GETDATE(), GETDATE())
    --VALUES  (3, 100000, 1000, 1, 100000, GETDATE(), GETDATE(), GETDATE())
    --VALUES (4, 100000, 1000, 1, 100000, GETDATE(), GETDATE(), GETDATE())
    VALUES  (5, 100000, 1000, 1, 100000, GETDATE(), GETDATE(), GETDATE())
    SELECT * FROM qoutes
    INSERT INTO maket_indexies (name, symbol)
    VALUES ('HNXINDEX', 'HNXINDEX'),
    ('UPCOMINDEX', 'UPCOMINDEX'),
    ('VN30', 'VN30'),
    ('HNX30', 'HNX30'),
    ('VNALLSHARE', 'VNALLSHARE')
    SELECT * FROM maket_indexies
    INSERT INTO index_coustituents (index_id, stock_id)
    VALUES (1,2),
    (1,3),
    (2,4),
    (3,5),
    (1,3),
    (2,2)
    SELECT * FROM index_coustituents
    GO
    CREATE VIEW _stock_index AS
    SELECT
    s.id,
    s.symbol,
    s.company_name,
    s.maket_cap,
    s.secror_en,
    s.secror,
    s.inductry_en, 
    s.inductry, 
    s.stock_type, 
    i.index_id,
    m.symbol AS index_symbol,
    m.name AS index_name
    FROM stock AS s
    INNER JOIN index_coustituents AS i  
    ON s.id = i.stock_id
    INNER JOIN maket_indexies AS m
    ON m.id = i.index_id;
    
GO
CREATE TRIGGER order_insert
ON orders
AFTER INSERT
AS
BEGIN
    DECLARE @user_id INT
    DECLARE @stock_id INT
    DECLARE @quantity INT
    DECLARE @purchase_price DECIMAL (10,4)
    DECLARE @purchase_date DATETIME
    DECLARE @notification_type NVARCHAR(50)
    DECLARE @notification_content NVARCHAR(255)
    DECLARE @transaction_type NVARCHAR(50)
    DECLARE @transaction_amount DECIMAL(10,2)
    DECLARE @transaction_date DATETIME
    DECLARE @order_id INT
    DECLARE @order_status NVARCHAR(20)
    DECLARE @direction NVARCHAR(20)
    SELECT @user_id = inserted.user_id,
            @stock_id = inserted.stock_id,
            @quantity = inserted.quantity,
            @purchase_price = inserted.price,
            @purchase_date = inserted.order_date,
            @order_id = inserted.order_id,
            @order_status = inserted.status,
            @direction = inserted.direction
    FROM inserted
    IF EXISTS (SELECT * FROM portfolio WHERE user_id = @user_id AND stock_id = @stock_id)
    BEGIN
        UPDATE portfolio SET 
        quantity = quantity + @quantity,
        purchase_price = ((quantity * purchase_price) + (@quantity * @purchase_price)) / (quantity + @quantity),
        purchase_date = CASE WHEN quantity + @quantity = 0 THEN NULL ELSE @purchase_date END
        WHERE user_id = @user_id AND stock_id = @stock_id
    END
    ELSE
    BEGIN
        INSERT INTO portfolio (user_id, stock_id, quantity, purchase_price, purchase_date)
        VALUES (@user_id, @stock_id, @quantity, @purchase_price, @purchase_date)
    END

    SET @notification_type = 'Order'
    SET @notification_content = CONCAT('Order #', @order_id, 'has been',@order_status)
    INSERT INTO notifications (user_id, notification_type, content)
    VALUES (@user_id, @notification_type, @notification_content)

    SET @transaction_type = CASE
    WHEN @direction = 'buy' THEN 'withdrawal'
    WHEN @direction = 'sell' THEN 'deposit'
    ELSE 'unknown' 
    END
    SET @transaction_amount = @quantity * @purchase_price
    SET @transaction_date = @purchase_date
    INSERT INTO transactions (user_id, transaction_type, amount, transaction_date)
    VALUES (@user_id, @transaction_type, @transaction_amount, @transaction_date)
END;
 drop trigger order_insert
SELECT * FROM portfolio WHERE user_id=1 AND stock_id=3;
INSERT INTO orders (user_id, stock_id, order_type, quantity, direction, price, status, order_date)
VALUES (1, 3, 'market', 100, 'buy', 100000, 'open', GETDATE())
SELECT * FROM portfolio WHERE user_id=1 AND stock_id=3;
GO
CREATE VIEW view_qoute_realtime AS
SELECT DISTINCT
q.stock_id,
q.price,
q.change,
q.precent_change,
q.volume,
q.time_stamp,
s.symbol,
s.company_name,
s.market_cap,
s.secror_en,
s.secror,
s.inductry_en,
s.inductry,
s.stock_type,
m.name as index_name,
m.symbol as index_symbol
FROM qoutes AS q
INNER JOIN stock s ON q.stock_id = s.stock_id
INNER JOIN index_coustituents i ON s.stock_id = i.stock_id
INNER JOIN maket_indexies m ON m.id = i.index_id
WHERE q.time_stamp = (SELECT MAX(time_stamp) FROM qoutes WHERE stock_id = q.stock_id)




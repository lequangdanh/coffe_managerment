create database quanlyquantrahoasua
go
use quanlyquantrahoasua
go


CREATE TABLE TableFood
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Bàn chưa có tên',
	status NVARCHAR(100) NOT NULL DEFAULT N'Trống'	-- Trống || Có người
)
GO

create procedure them_TableFood @name nvarchar(100)
as
begin
insert into dbo.TableFood(name)values(@name)
end

create procedure sua_TableFood @id int,@name nvarchar(100),@status nvarchar(100)
as
begin
 update dbo.TableFood set name=@name,status =@status where id=@id 
end

exec sua_TableFood 15,'Bàn 14',N'Trống'

create procedure xoa_TableFood @id int
as
begin
delete dbo.TableFood where id=@id
end

create procedure tim_TableFood @name nvarchar(100) 
as
begin
select * from dbo.TableFood where name like'%'+@name+'%'
end

exec tim_TableFood'Bàn 11'

exec xoa_TableFood 15
select *from dbo.TableFood

CREATE TABLE Account
(
	UserName NVARCHAR(100) PRIMARY KEY,	
	PassWord NVARCHAR(1000) NOT NULL,
	
)
GO
insert into dbo.Account values('admin','admin')

CREATE TABLE FoodCategory
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên'
)
GO
select * from dbo.FoodCategory

create procedure them_Category @name nvarchar(100)
as
begin
insert into dbo.FoodCategory(name)values(@name)
end

exec them_Category 'khona'

create procedure sua_Category @id int,@name nvarchar(100)
as
begin
 update dbo.FoodCategory set name=@name where id=@id 
end
exec sua_Category 11,'khon'


create procedure xoa_Category @id int
as
begin
delete dbo.FoodCategory where id=@id
end
exec xoa_Category 11

create procedure tim_Category @name nvarchar(100) 
as
begin
select * from dbo.FoodCategory where name like'%'+@name+'%'
end

exec tim_Category N'Nước'

exec xoa_TableFood 15
select *from dbo.TableFood


CREATE TABLE Food
(
	id INT IDENTITY PRIMARY KEY,
	name NVARCHAR(100) NOT NULL DEFAULT N'Chưa đặt tên',
	idCategory INT NOT NULL,
	price FLOAT NOT NULL DEFAULT 0
	
	FOREIGN KEY (idCategory) REFERENCES dbo.FoodCategory(id)
)
GO



create procedure them_Food @name nvarchar(100),@idCategory int,@price float
as
begin
insert into dbo.Food values(@name,@idCategory,@price)
end

exec them_Food 'coca',5,20000

create procedure sua_Food @id int,@name nvarchar(100),@idCategory int,@price float
as
begin
update dbo.Food set name=@name,idCategory=@idCategory,price=@price where id=@id
end

exec sua_Food 15,'cocacola',5,20000

create procedure xoa_Food @id int
as
begin
delete dbo.Food where id=@id
end

exec xoa_Food 15

create procedure tim_Food @name nvarchar(100)
as
begin
select*from dbo.Food where name=@name
end

exec tim_Food '7Up'
select *from dbo.Food



CREATE TABLE Bill
(
	id INT IDENTITY PRIMARY KEY,
	DateCheckIn DATE NOT NULL DEFAULT GETDATE(),
	DateCheckOut DATE,
	idTable INT NOT NULL,
	status INT NOT NULL DEFAULT 0 -- 1: đã thanh toán && 0: chưa thanh toán
	
	FOREIGN KEY (idTable) REFERENCES dbo.TableFood(id)
)
GO
select * from dbo.Bill

CREATE TABLE BillInfo
(
	id INT IDENTITY PRIMARY KEY,
	idBill INT NOT NULL,
	idFood INT NOT NULL,
	count INT NOT NULL DEFAULT 0
	
	FOREIGN KEY (idBill) REFERENCES dbo.Bill(id),
	FOREIGN KEY (idFood) REFERENCES dbo.Food(id)
)
GO

INSERT INTO dbo.Account
        ( UserName ,
          DisplayName ,
          PassWord ,
          Type
        )
VALUES  ( N'K9' , -- UserName - nvarchar(100)
          N'RongK9' , -- DisplayName - nvarchar(100)
          N'1' , -- PassWord - nvarchar(1000)
          1  -- Type - int
        )
INSERT INTO dbo.Account
        ( UserName ,
          DisplayName ,
          PassWord ,
          Type
        )
VALUES  ( N'staff' , -- UserName - nvarchar(100)
          N'staff' , -- DisplayName - nvarchar(100)
          N'1' , -- PassWord - nvarchar(1000)
          0  -- Type - int
        )
GO

CREATE PROC USP_GetAccountByUserName
@userName nvarchar(100)
AS 
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName
END
GO

EXEC dbo.USP_GetAccountByUserName @userName = N'k9' -- nvarchar(100)

GO

CREATE PROC USP_Login
@userName nvarchar(100), @passWord nvarchar(100)
AS
BEGIN
	SELECT * FROM dbo.Account WHERE UserName = @userName AND PassWord = @passWord
END
GO

-- thêm bàn
DECLARE @i INT = 0

WHILE @i <= 10
BEGIN
	INSERT dbo.TableFood ( name)VALUES  ( N'Bàn ' + CAST(@i AS nvarchar(100)))
	SET @i = @i + 1
END
GO

---------------- thủ tục xem bàn ----------------

CREATE PROC xem_ban
AS SELECT * FROM dbo.TableFood
GO

UPDATE dbo.TableFood SET STATUS = N'Trống' WHERE id = 9


-- thêm category
INSERT dbo.FoodCategory
        ( name )
VALUES  ( N'Hải sản'  -- name - nvarchar(100)
          )
INSERT dbo.FoodCategory
        ( name )
VALUES  ( N'Nông sản' )
INSERT dbo.FoodCategory
        ( name )
VALUES  ( N'Lâm sản' )
INSERT dbo.FoodCategory
        ( name )
VALUES  ( N'Sản sản' )
INSERT dbo.FoodCategory
        ( name )
VALUES  ( N'Nước' )

-- thêm món ăn
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Mực một nắng nước sa tế', -- name - nvarchar(100)
          1, -- idCategory - int
          120000)
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Nghêu hấp xả', 1, 50000)
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Dú dê nướng sữa', 2, 60000)
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Heo rừng nướng muối ớt', 3, 75000)
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Cơm chiên mushi', 4, 999999)
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'7Up', 5, 15000)
INSERT dbo.Food
        ( name, idCategory, price )
VALUES  ( N'Cafe', 5, 12000)

-- thêm bill
INSERT	dbo.Bill
        ( DateCheckIn ,
          DateCheckOut ,
          idTable ,
          status
        )
VALUES  ( GETDATE() , -- DateCheckIn - date
          NULL , -- DateCheckOut - date
          3 , -- idTable - int
          0  -- status - int
        )
        
INSERT	dbo.Bill
        ( DateCheckIn ,
          DateCheckOut ,
          idTable ,
          status
        )
VALUES  ( GETDATE() , -- DateCheckIn - date
          NULL , -- DateCheckOut - date
          4, -- idTable - int
          0  -- status - int
        )
INSERT	dbo.Bill
        ( DateCheckIn ,
          DateCheckOut ,
          idTable ,
          status
        )
VALUES  ( GETDATE() , -- DateCheckIn - date
          GETDATE() , -- DateCheckOut - date
          5 , -- idTable - int
          1  -- status - int
        )

-- thêm bill info
INSERT	dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 5, -- idBill - int
          1, -- idFood - int
          2  -- count - int
          )
INSERT	dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 5, -- idBill - int
          3, -- idFood - int
          4  -- count - int
          )
INSERT	dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 5, -- idBill - int
          5, -- idFood - int
          1  -- count - int
          )
INSERT	dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 6, -- idBill - int
          1, -- idFood - int
          2  -- count - int
          )
INSERT	dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 6, -- idBill - int
          6, -- idFood - int
          2  -- count - int
          )
INSERT	dbo.BillInfo
        ( idBill, idFood, count )
VALUES  ( 7, -- idBill - int
          5, -- idFood - int
          2  -- count - int
          )         
          
GO
CREATE TRIGGER UTG_UpdateBillInfo
ON dbo.BillInfo FOR INSERT, UPDATE
AS
BEGIN
	DECLARE @idBill INT
	
	SELECT @idBill = idBill FROM Inserted
	
	DECLARE @idTable INT
	
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill AND status = 0
	
	UPDATE dbo.TableFood SET status = N'Có người' WHERE id = @idTable
END
GO
select * from dbo.Bill
ALTER TABLE dbo.Bill
ADD discount INT
UPDATE dbo.Bill SET discount = 0
GO

CREATE TRIGGER UTG_UpdateBill
ON dbo.Bill FOR UPDATE
AS
BEGIN
	DECLARE @idBill INT
	
	SELECT @idBill = id FROM Inserted	
	
	DECLARE @idTable INT
	
	SELECT @idTable = idTable FROM dbo.Bill WHERE id = @idBill
	
	DECLARE @count int = 0
	
	SELECT @count = COUNT(*) FROM dbo.Bill WHERE idTable = @idTable AND status = 0
	
	IF (@count = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable
END
GO

alter table dbo.BillInfo add discount int
select *from dbo.Bill
select *from dbo.Food
--create procedure USP_InsertBill @idTable int
--as
--begin
--insert into dbo.Bill values(getdate(),null,@idTable,0)
--end
--exec USP_InsertBill
------------ thủ tục thêm bill----------------
CREATE PROC them_Bill
@idTable INT
AS
BEGIN
	INSERT dbo.Bill 
	        ( DateCheckIn ,
	          DateCheckOut ,
	          idTable ,
	          status,
	          discount
	        )
	VALUES  ( GETDATE() , -- DateCheckIn - date
	          NULL , -- DateCheckOut - date
	          @idTable , -- idTable - int
	          0,  -- status - int
	          0
	        )
END
GO

---------- thủ tục thêm billinfo------------------------------------------

create procedure them_BillInfo 
@idBill int , @idFood int, @count int
as
begin
insert into dbo.BillInfo(idBill,idFood,count) values(@idBill,@idFood,@count)
end

insert into dbo.taikhoan values(N'admin',N'admin')

select * from dbo.khachhang

---- thủ tục chuyển bàn----------------------------
CREATE PROC chuyenban
@idTable1 INT, @idTable2 int
AS BEGIN

	DECLARE @idFirstBill int
	DECLARE @idSeconrdBill INT
	
	DECLARE @isFirstTablEmty INT = 1
	DECLARE @isSecondTablEmty INT = 1
	
	
	SELECT @idSeconrdBill = id FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
	SELECT @idFirstBill = id FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'
	
	IF (@idFirstBill IS NULL)
	BEGIN
		PRINT '0000001'
		INSERT dbo.Bill
		        ( DateCheckIn ,
		          DateCheckOut ,
		          idTable ,
		          status
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable1 , -- idTable - int
		          0  -- status - int
		        )
		        
		SELECT @idFirstBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable1 AND status = 0
		
	END
	
	SELECT @isFirstTablEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idFirstBill
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'
	
	IF (@idSeconrdBill IS NULL)
	BEGIN
		PRINT '0000002'
		INSERT dbo.Bill
		        ( DateCheckIn ,
		          DateCheckOut ,
		          idTable ,
		          status
		        )
		VALUES  ( GETDATE() , -- DateCheckIn - date
		          NULL , -- DateCheckOut - date
		          @idTable2 , -- idTable - int
		          0  -- status - int
		        )
		SELECT @idSeconrdBill = MAX(id) FROM dbo.Bill WHERE idTable = @idTable2 AND status = 0
		
	END
	
	SELECT @isSecondTablEmty = COUNT(*) FROM dbo.BillInfo WHERE idBill = @idSeconrdBill
	
	PRINT @idFirstBill
	PRINT @idSeconrdBill
	PRINT '-----------'

	SELECT id INTO IDBillInfoTable FROM dbo.BillInfo WHERE idBill = @idSeconrdBill
	
	UPDATE dbo.BillInfo SET idBill = @idSeconrdBill WHERE idBill = @idFirstBill
	
	UPDATE dbo.BillInfo SET idBill = @idFirstBill WHERE id IN (SELECT * FROM IDBillInfoTable)
	
	DROP TABLE IDBillInfoTable
	
	IF (@isFirstTablEmty = 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable2
		
	IF (@isSecondTablEmty= 0)
		UPDATE dbo.TableFood SET status = N'Trống' WHERE id = @idTable1
END
GO
---------------------------------------------------procedure khach hang-----------------------------------------


exec tim_khuyenmai 'KM0001'

declare @i int =0
while @i<=10
begin
 insert into dbo.banan (name) values (N'Bàn' +CAST(@i as nvarchar(100)))
 set @i = @i +1
 end
 select*from dbo.banan


 

alter table dbo.Bill add totalPrice int

delete  dbo.Bill
delete  dbo.BillInfo

CREATE PROC thongke_Bill
@checkIn date, @checkOut date
AS 
BEGIN
	SELECT t.name AS [Tên bàn], DateCheckIn AS [Ngày vào], DateCheckOut AS [Ngày ra], discount AS [Giảm giá], b.totalPrice AS [Tổng tiền]
	FROM dbo.Bill AS b,dbo.TableFood AS t
	WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1
	AND t.id = b.idTable
END
GO
select * from dbo.Bill

CREATE PROC thongke_Bill4
@checkIn date, @checkOut date
AS 
BEGIN
	SELECT t.id, DateCheckIn,idTable, b.status,DateCheckOut, discount , b.totalPrice FROM dbo.Bill AS b,dbo.TableFood AS t WHERE DateCheckIn >= @checkIn AND DateCheckOut <= @checkOut AND b.status = 1 AND t.id = b.idTable
END
GO

SELECT t.name AS [Tên bàn], DateCheckIn AS [Ngày vào], DateCheckOut AS [Ngày ra], discount AS [Giảm giá], b.totalPrice AS [Tổng tiền] FROM dbo.Bill AS b,dbo.TableFood AS t WHERE DateCheckIn >= '2021-05-20' AND DateCheckOut <= '2021-05-21' AND b.status = 1 AND t.id = b.idTable

--UserName NVARCHAR(100) PRIMARY KEY,	
--	PassWord NVARCHAR(1000) NOT NULL,

--- thủ tục cho chức năng đổi mật khẩu
create procedure changepass @Username nvarchar(100),@PassWord nvarchar(100),@NewPassWord nvarchar(100),@ComfirmPassWord nvarchar(100)
as
begin
 update dbo.Account set PassWord=@NewPassWord where PassWord=@PassWord and UserName = @Username and @NewPassWord=@ComfirmPassWord
 end

 exec changepass'admin','admin','bdmin','bdmin'
 --- câu lệnh truy vấn cho chức năng đăng nhập
 select * from dbo.Account where UserName='admin' and PassWord='anhdanh321'

 --- lấy bill chưa check theo mã bàn
 SELECT * FROM dbo.Bill WHERE idTable =1 AND status = 0
 
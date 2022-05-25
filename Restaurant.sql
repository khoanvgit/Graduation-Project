USE master
GO

IF EXISTS (SELECT * FROM sys.databases WHERE name = 'Restaurant')
BEGIN
	DROP DATABASE Restaurant;
END;
CREATE DATABASE Restaurant;
GO

USE Restaurant
GO

--Table customers
CREATE TABLE Customers (
  CustomerID int NOT NULL PRIMARY KEY IDENTITY,
  FirstName varchar(200),
  LastName varchar(200),
  Email varchar(200),
  [Address] varchar(200),
  City varchar(200),
  Phone varchar(20) NOT NULL,
  Birthday date NULL,
)
GO
-- Insert data
INSERT INTO Customers VALUES 
('Maggi','Domney','mdomney0@wisdompets.com','53177 Fieldstone Pass','San Bernardino','760-702-5469','1938-10-11'),
('Javier','Dawks','jdawks1@red30design.com','25629 Brown Trail','Hartford','860-906-1459','1953-11-21'),
('Aleen','Fasey','afasey2@kinetecoinc.com','41967 Mockingbird Court','Boca Raton','561-410-2222','1900-08-10'),
('Taylor','Jenkins','tjenkins@rouxacademy.org','968 Bartillon Park','Fort Lauderdale','954-294-7424','1961-05-02'),
('Imogen','Kabsch','ikabsch@landonhotel.com','222 Hudson Point','Anderson','864-326-7456','1919-08-27'),
('Dunc','Winny','dwinny5@kinetecoinc.com','6 Derek Avenue','Columbus','706-389-4923','1919-07-19'),
('Cammi','Kynett','ckynett6@orangevalleycaa.org','237 Homewood Hill','Washington','202-798-6252','1927-03-06'),
('Steffie','Kleis','skleis7@wisdompets.com','360 Little Fleur Park','Evansville','812-301-6915','1957-12-27'),
('Carilyn','Calver','ccalver8@samoca.org','3664 Emmet Circle','Dulles','571-718-5931','1960-12-17'),
('Barbara-anne','Sweet','bsweet9@samoca.org','257 Mallory Drive','San Antonio','210-776-2859','1911-04-01'),
('Faina','Nelles','fnellesa@red30design.com','1143 Nevada Plaza','Reading','484-145-8882','1967-03-06'),
('Orton','Stavers','ostaversb@orangevalleycaa.org','5 Pankratz Junction','Vienna','571-414-2322','1910-07-20'),
('Jobina','McKern','jmckernc@rouxacademy.org','28 Dovetail Circle','San Mateo','805-540-9168','1923-01-19'),
('Paco','Yarranton','pyarrantond@rouxacademy.org','1 Lighthouse Bay Hill','Columbus','614-173-1770','1977-05-08'),
('Chance','Todeo','ctodeoe@wisdompets.com','2 Debra Trail','Dallas','214-351-1058','1924-08-13'),
('Carla','Swinfen','cswinfenf@kinetecoinc.com','949 Northview Junction','South Bend','574-883-7972','1989-05-24'),
('Lani','Over','loverg@wisdompets.com','8 Roxbury Point','Colorado Springs','719-792-4724','1938-08-02'),
('Anthe','Dinjes','adinjesh@samoca.org','4 American Road','Washington','202-164-5786','1903-12-29'),
('Amby','Harber','aharberi@hplussport.com','2985 Pearson Circle','Durham','919-557-3321','1925-06-21'),
('Jacinta','Vallis','jvallisj@kinetecoinc.com','9 Anzinger Lane','Bakersfield','661-103-5365','1994-12-10')
GO

-- Table Staffs
CREATE TABLE Staffs (
  StaffID int NOT NULL PRIMARY KEY IDENTITY,
  GroupID int NOT NULL,
  FirstName varchar(200) NOT NULL,
  LastName varchar(200) NOT NULL,
  Gender char(1) NULL,
  Email varchar(200) NULL,
  [Address] varchar(200) NULL,
  City varchar(200) NULL,
  Phone varchar(13) NOT NULL,
  Birthday date NULL,
  [Image] varchar(255) NULL
)
GO

-- Insert data
INSERT INTO Staffs VALUES
(1,'Emlyn','Attwool','F','eattwoolt@hplussport.com','289 Westridge Pass','Des Moines','515-478-3690','1996-08-12',null),
(2,'Osgood','Saunter','M','osaunteru@red30design.com','9686 Havey Crossing','Oklahoma City','405-620-8345','1994-12-18',null),
(3,'Demetri','Iacobacci','M','diacobacciv@landonhotel.com','1727 Vermont Point','Newark','302-843-4915','1998-05-05',null),
(3,'Eloisa','Forster','F','eforsterw@wisdompets.com','45084 Butterfield Point','Kalamazoo','269-400-8205','1998-06-22',null),
(3,'Carlin','Casterou','M','ccasteroux@landonhotel.com','17 Cordelia Trail','El Paso','915-815-0411','1990-06-10',null),
(3,'Luciano','Winton','M','lwintony@hplussport.com','386 Fairview Lane','Greensboro','336-968-8032','1991-04-16',null),
(2,'Allyson','Jira','F','ajiraz@wisdompets.com','51474 Northridge Pass','Syracuse','315-720-5302','1986-01-23',null),
(4,'Jillane','Livingstone','F','jlivingstone10@wisdompets.com','4 Arizona Hill','Fairfax','571-135-9052','1988-09-30',null),
(2,'Christyna','McGilroy','F','cmcgilroy11@landonhotel.com','47989 East Court','Washington','202-132-1057','1984-08-01',null),
(4,'Oralla','Dayer','F','odayer12@samoca.org','478 Sommers Pass','Sacramento','916-274-8584','1977-05-27',null),
(5,'Angelique','Farnham','F','afarnham13@wisdompets.com','564 Ohio Crossing','Fort Smith','479-118-1613','1989-06-02',null)
GO

-- Table Groups
CREATE TABLE Groups(
	GroupID int NOT NULL PRIMARY KEY IDENTITY,
	[Name] varchar(200) NOT NULL,
	[Description] text NULL
)
GO
-- Insert data
INSERT INTO Groups VALUES
('Receptionist','Making sure that customers get the best services obtainable in the restaurant, and this begins from the moment they walk into the restaurant to when they leave.'),
('Cook Assistant','Washing and cleaning the kitchen and food preparation area.'),
('Waiter/ waitress','greeting and serving customers, providing detailed information on menus, multi-tasking various front-of-the-house duties and collecting the bill.'),
('Chef','Chef responsibilities include studying recipes, setting up menus and preparing high-quality dishes.'),
('Accountant','Preparing accounts, budgeting and managing financial information')
GO

-- Table GroupDivision
CREATE TABLE GroupDivision(
	StaffID int NOT NULL,
	GroupID int NOT NULL,
	PRIMARY KEY(StaffID, GroupID),
	CONSTRAINT fkGroupDivision_StaffID FOREIGN KEY (StaffID) REFERENCES Staffs(StaffID),
	CONSTRAINT fkGroupDivision_GroupID FOREIGN KEY (GroupID) REFERENCES Groups(GroupID)
)
GO
-- Insert data
INSERT INTO GroupDivision VALUES
(1,1),
(2,2),
(3,3),
(4,3),
(5,3),
(6,3),
(7,2),
(8,4),
(9,2),
(10,4),
(11,5)
GO

-- Table Ingredient
/* Reference : https://food.ndtv.com/ingredient */

CREATE TABLE Ingredient (
  IngredientID int NOT NULL PRIMARY KEY IDENTITY,
  [Name] varchar(200) NULL,
  CalculationUnit varchar(50) NOT NULL,
  [Description] text NULL,
  [Image] varchar(255) NULL
)
GO
-- Insert data
INSERT INTO Ingredient VALUES
('Cherry Tomatoes','Kg','Cherry tomatoes are a smaller variety of the garden tomatoes, which are comparatively sweeter than the larger fruits. 
They are relatively found in size of a thumb tip to the size of a golfball. These varieties of tomatoes are even juicier and hold many valuable nutrients.',null),
('Mushroom','Kg','Mushrooms are fleshy, edible fungi that are a low-calorie food and a good source of Vitamin B. Shiitake, porcini and chanterelle are some 
types of mushrooms. The edibility of mushroom depends on the absence of poisonous effects on humans and the desirable taste and aroma. They are somewhat
meaty in flavor and taste and are also a great source of Vitamin D.',null),
('Beef','Kg','Derived from the Latin word bos , meat from the cattle is known as ‘beef’. Beef muscle meat can be cut into steak, roasts or short ribs.',null),
('Kiwi','Kg','Kiwi fruit or kiwi berry is an edible berry that has a soft texture and a sweet flesh. The fibrous greenish-brown outer portion shields the 
bright green flesh. The center of the fruit has black tiny edible seeds. Kiwi fruit is now a commercial crop in countries like Italy, France, Greece and New Zealand.',null)
GO

-- Table DishType
/* Reference : https://www.jamieoliver.com/recipes/category/dishtype/ */
CREATE TABLE DishType (
  DishTypeID int NOT NULL PRIMARY KEY IDENTITY,
  [Name] varchar(200) NULL,
  [Description] text NULL
)
GO
-- Insert data
INSERT INTO DishType VALUES
('Salad','Whether you’re after a light lunch or a quick supper, having a few salad recipes up your sleeve is a great way to guarantee vibrant, veg-packed meals. And the best thing about them? Just about anything goes. You can’t beat a simple Caesar, a fresh and zingy Asian-inpired number, or a hearty roasted veg salad.'),
('Soup','Whether it’s a classic minestrone, a hearty ramen or a vibrant tomato, there’s nothing like a comforting bowl of delicious soup. These recipes are fully flexible and perfect for using up leftovers or adapting to whatever you have at home. Make a big batch at the beginning of the week and you’ll have lunch sorted for days.'),
('Pizza','Whether it’s gluten-free, deep-pan or thin crust our pizza recipe collection has you covered. Make your own pizza dough and the possibilities for toppings are endless!'),
('Stew','Our hearty stew recipes are perfect for a midweek dinner or winter weekend, slow cooked or on the table in less than 30 minutes, we’ve got the stew for you.')
GO

-- Table Dishes
CREATE TABLE Dishes (
  DishID int NOT NULL PRIMARY KEY IDENTITY,
  DishTypeID int NOT NULL,
  [Name] varchar(200) DEFAULT NULL,
  [Description] text DEFAULT NULL,
  Price decimal DEFAULT NULL,
  [Image] varchar(20) NULL,
  CONSTRAINT fk_DishTypeID FOREIGN KEY (DishTypeID) REFERENCES DishType(DishTypeID)
)
GO
-- Insert data
INSERT INTO Dishes VALUES
(1,'Parmesan Deviled Eggs ','These delectable little bites are made with organic eggs, fresh Parmesan, and chopped pine nuts.',8.00,'eggs.jpg'),
(2,'Artichokes with Garlic Aioli','Our artichokes are brushed with an olive oil and rosemary blend and then broiled to perfection. Served with a side of creamy garlic aioli.',9.00,'Artichokes.jpg'),
(3,'French Onion Soup','Caramelized onions slow cooked in a savory broth, topped with sourdough and a provolone cheese blend. Served with sourdough bread.',7.00,'FOS.jpg'),
(4,'Mini Cheeseburgers ','These mini cheeseburgers are served on a fresh baked pretzel bun with lettuce, tomato, avocado, and your choice of cheese.',8.00,'MC.jpg'),
(1,'Panko Stuffed Mushrooms ','Large mushroom caps are filled a savory cream cheese, bacon and panko breadcrumb stuffing, topped with cheddar cheese. ',7.00,'PSM.jpg'),
(2,'Garden Buffet','Choose from our fresh local, organically grown ingredients to make a custom salad.',9.99,'GB.jpg'),
(3,'House Salad','Our house salad is made with romaine lettuce and spinach, topped with tomatoes, cucumbers, red onions and carrots. Served with a dressing of your choice.',7.00,'HS.jpeg'),
(4,'Chef''s Salad','The chef''s salad has cucumber, tomatoes, red onions, mushrooms, hard-boiled eggs, cheese, and hot grilled chicken on a bed of romaine lettuce. Served with croutons and your choice of dressing.',9.00,'CS.jpeg'),
(1,'Quinoa Salmon Salad','Our quinoa salad is served with quinoa, tomatoes, cucumber, scallions, and smoked salmon. Served with your choice of dressing.',9.99,'image.jpg'),
(2,'Classic Burger','Our classic burger is made with 100% pure angus beef, served with lettuce, tomatoes, onions, pickles, and cheese of your choice. Veggie burger available upon request. Served with French fries, fresh fruit, or a side salad.',9.99,'Burger.jpg'),
(3,'Tomato Bruschetta Tortellini','This classic cheese tortellini is cooked in a sundried tomato sauce. Served with bruschetta topped with a tomato and basil marinara.',9.99,'TBT.jpg'),
(4,'Handcrafted Pizza','Our thin crust pizzas are made fresh daily and topped with your choices of fresh meats, veggies, cheese, and sauce.  Price includes two toppings. Add $1 for each additional topping.',9.99,'HP.jpg'),
(1,'Barbecued Tofu Skewers','Our barbecued skewers include tofu, cherry tomatoes, bell peppers, and zucchini marinated in a ginger sesame sauce and charbroiled. Served with steamed rice.',9.99,'Barbecued.jpg'),
(2,'Fiesta Family Platter','This platter is perfect for sharing! Enjoy our spicy buffalo wings, traditional nachos, and cheese quesadillas served with freshly made guacamole dip.',9.99,'Fiesta.jpg'),
(3,'Creme Brulee','Elegantly crafted creamy vanilla custard with a caramelized crunchy layer on top. Served with seasonal fruit.',9.00,'Creme.jpg'),
(4,'Cheesecake','Our New York Style Cheesecake is rich, smooth, and creamy. Available in various flavors, and with seasonal fruit toppings.',9.00,'cake.jpg'),
(1,'Chocolate Chip Brownie ','A warm chocolate chip brownie served with chocolate or vanilla ice cream and rich chocolate sauce.',6.00,'Chocolate.jpg'),
(2,'Apple Pie','Made with local granny smith apples to bring you the freshest classic apple pie available.',5.00,'AP.jpg'),
(3,'Mixed Berry Tart','Raspberries, blueberries, and strawberries on top of a creamy filling served in a crispy tart.',7.00,'MBT.jpg'),
(4,'Tropical Blue Smoothie','This blueberry mint-based smoothie is refreshing and perfect for any celebration.',6.00,'TBS.jpg'),
(1,'Pomegranate Iced Tea','Our unique blend of pomegranate juice, black Rooibos, and mint tea creates this light fusion of flavors.  ',4.00,'PIT.jpg'),
(2,'Cafe Latte','Our house blend of espresso and foamed milk. Can be served with flavored syrups and over ice.  Non-dairy substitutions available upon request.',6.00,'Cafe.jpg')
GO

-- Table Orders
CREATE TABLE Orders (
  OrderID int NOT NULL PRIMARY KEY IDENTITY,
  CustomerID int NULL,
  TableNumber int NOT NULL,
  OrderDate datetime2(0) NULL,
  CONSTRAINT fk_CustomerID FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)
GO
-- Insert data
INSERT INTO Orders VALUES 
(17,1,'2022-03-01 17:32:00'),
(17,1,'2022-03-02 08:52:00'),
(2,2,'2022-03-02 16:53:00'),
(15,3,'2022-03-02 16:58:00'),
(16,4,'2022-03-03 12:04:00'),
(19,5,'2022-03-04 14:31:00'),
(11,6,'2022-03-05 11:31:00'),
(17,1,'2021-03-15 16:22:00'),
(1,7,'2021-03-15 18:29:00'),
(16,15,'2020-12-15 19:25:00')
GO

-- Table OrderDetails
CREATE TABLE OrderDetails (
  OrderID int NOT NULL,
  DishID int NOT NULL,
  DishNumber int NOT NULL
  PRIMARY KEY(OrderID, DishID),
  CONSTRAINT fk_OrderID FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
  CONSTRAINT fk_DishID FOREIGN KEY (DishID) REFERENCES Dishes(DishID)
)
GO
-- Insert data
INSERT INTO OrderDetails VALUES 
(1,3,2),
(2,4,1),
(3,21,1),
(4,3,1),
(5,8,2),
(6,2,2),
(7,8,1),
(8,9,1),
(9,7,1),
(10,4,1)
GO

/*
-- Table Sales
CREATE TABLE Sales (
	SaleCode char(10) NOT NULL PRIMARY KEY,
	Name varchar(200)
)
GO
-- Insert data
INSERT INTO Sales VALUES
('K58934YHO1','Black Friday'),
('Z283UHF110','Halloween'),
('NEW-FRIEND','Bring more new friends'),
('FIRSTTIME1','Welcome to our Restaurant'),
('MOREISFUN1','Family is the best')
GO

-- Table SaleDish
CREATE TABLE SaleDish (
	DishID int NOT NULL,
	SaleCode char(10),
	TimeBegin datetime,
	TimeFinish datetime,
	Value varchar(50) NOT NULL,
	Content ntext,
	PRIMARY KEY(DishID, SaleCode),
	CONSTRAINT fkSaleDish_DishID FOREIGN KEY (DishID) REFERENCES Dishes(DishID),
	CONSTRAINT fkSaleDish_SaleCode FOREIGN KEY (SaleCode) REFERENCES Sales(SaleCode)
)
GO
-- Insert data
INSERT INTO SaleDish VALUES
(1,'K58934YHO1','2021-06-03','2021-08-03','20% Up to 10$','Sock sock'),
(2,'Z283UHF110','2021-06-03','2021-08-03','10% Up to 5$','Scary dish'),
(3,'NEW-FRIEND','2021-06-03','2021-08-03','10% Up to 9.99$','It is for your friend haha'),
(4,'FIRSTTIME1','2021-06-03','2021-08-03','5% Up to 20$','You choosed right place'),
(5,'MOREISFUN1','2021-06-03','2021-08-03','5% Up to 30$ from 100$','More people more fun')
GO
*/

-- Table StockIn
CREATE TABLE StockIn(
	StockInID int NOT NULL PRIMARY KEY IDENTITY,
	StaffID int NOT NULL,
	ReceiveDate date NOT NULL,
	CONSTRAINT fk_StaffID FOREIGN KEY (StaffID) REFERENCES Staffs(StaffID)
)
GO
-- Insert data
INSERT INTO StockIn VALUES
(1,'2021-02-21'),
(2,'2021-03-01'),
(2,'2021-04-12'),
(3,'2021-04-19'),
(4,'2021-05-06')
GO

-- Table GoodsReceiptNote
CREATE TABLE GoodsReceiptNote(
	StockInID int NOT NULL,
	IngredientID int NOT NULL,
	GoodsUnitPrice decimal NOT NULL,
	GoodsNumber int NOT NULL,
	[Location] varchar(200),
	PRIMARY KEY(StockInId, IngredientID),
	CONSTRAINT fk_StockInID FOREIGN KEY (StockInID) REFERENCES StockIn(StockInID),
	CONSTRAINT fk_IngredientID FOREIGN KEY (IngredientID) REFERENCES Ingredient(IngredientID)
)
GO
-- Insert data
INSERT INTO GoodsReceiptNote VALUES
(1,1,2.5,20,'Hanoi, Vietnam'),
(2,2,1.25,10,'Hanoi, Vietnam'),
(3,1,3.5,20,'Hanoi, Vietnam'),
(4,3,4.5,15,'Hanoi, Vietnam'),
(5,4,6,30,'Hanoi, Vietnam')
GO

-- Table Reviews
CREATE TABLE Reviews(
	Id int PRIMARY KEY IDENTITY,
	CustomerName nvarchar(200) NOT NULL,
	ReviewDate date NOT NULL,
	Content ntext NOT NULL,
)
GO

-- Insert data
INSERT INTO Reviews VALUES
('Perky','2021-05-21','Amazing good job em'),
('Douglas','2021-04-01','The best dish I have ever eaten'),
('Bevemin','2021-01-12','Not so good'),
('Christ','2021-01-19','So delicious !'),
('Leo','2021-08-06','The best of the best')
GO

-- Table Payment
CREATE TABLE Payment(
	PaymentID int NOT NULL PRIMARY KEY IDENTITY,
	OrderID int NOT NULL,
	CustomerID int NOT NULL,
	PaymentDate datetime NOT NULL,
	ModeOfPayment varchar(100),
	TotalMoney decimal,
	CONSTRAINT fkPayment_OrderID FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
	CONSTRAINT fkPayment_CustomerID FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
)
GO
-- Insert data
INSERT INTO Payment VALUES
(1,17,'2022-03-01 21:32:00','Cash',655.5),
(2,17,'2022-03-02 10:52:00','Credit card',1245.5),
(3,2,'2022-03-02 20:52:00','Cash',877.2),
(8,17,'2021-06-01','Cash',655.5),
(9,1,'2021-05-01','Credit card',1245.5),
(10,16,'2021-07-01','Cash',877.2)
GO

-- Table Shifts
CREATE TABLE Shifts(
	ShiftID int NOT NULL PRIMARY KEY IDENTITY,
	[Name] varchar(50) NOT NULL,
	TimeBegin varchar(20) NOT NULL,
	TimeFinish varchar(20) NOT NULL
)
GO

-- Insert data
INSERT INTO Shifts VALUES
('Morning','8h','12h'),
('Afternoon','12h','18h'),
('Night','18h','22h')
GO

-- Table ShiftDetails
CREATE TABLE ShiftDetails(
	ShiftID int NOT NULL,
	StaffID int NOT NULL,
	PRIMARY KEY(ShiftID, StaffID),
	CONSTRAINT fkShiftDetails_ShiftID FOREIGN KEY (ShiftID) REFERENCES Shifts(ShiftID),
	CONSTRAINT fkShiftDetails_StaffID FOREIGN KEY (StaffID) REFERENCES Staffs(StaffID)
)
GO
-- Insert data
INSERT INTO ShiftDetails VALUES
(1,1),
(2,2),
(2,3),
(2,4),
(3,5),
(3,6),
(1,7),
(2,8),
(2,9),
(2,10),
(3,11),
(3,2)
GO

CREATE TABLE Tables
(
	Number int NOT NULL PRIMARY KEY,
	[Status] varchar(10) NOT NULL
)
GO

INSERT INTO Tables VALUES
(1,'available'),
(2,'available'),
(3,'busy'),
(4,'busy'),
(5,'busy'),
(6,'busy'),
(7,'available'),
(8,'available'),
(9,'available'),
(10,'available'),
(11,'available'),
(12,'available'),
(13,'available'),
(14,'available'),
(15,'available'),
(16,'available'),
(17,'available'),
(18,'available'),
(19,'available'),
(20,'available'),
(21,'available'),
(22,'available'),
(23,'available'),
(24,'available')
GO

-- Table Reservation
CREATE TABLE Reservations
(
  ReservationID int PRIMARY KEY IDENTITY(1,1),
  CustomerName nvarchar(200) NOT NULL,
  PhoneNumber varchar(13) NOT NULL,
  ReservedDate datetime2 NOT NULL,
  VIPRoom bit,
  NumberOfPeople int NOT NULL,
  TableNumber int NOT NULL,
  CONSTRAINT fkReservation_TableNumber FOREIGN KEY (TableNumber) REFERENCES Tables(Number)
)
GO
-- Insert data
INSERT INTO Reservations VALUES 
('Movis','105-620-8341','2021-12-03 15:15:00',0,2,2),
('Alex','305-620-8341','2021-06-03 15:15:00',1,4,10),
('Melody','215-620-8341','2021-07-03 15:15:00',0,2,15),
('Minh','450-620-8341','2021-03-08 15:15:00',0,3,7),
('Bran','499-620-8341','2021-09-09 15:15:00',1,2,3),
('Lin','405-627-8341','2022-02-03 15:15:00',0,2,1),
('Harris','405-611-8341','2021-02-05 14:00:00',0,6,10),
('Damon','405-620-2341','2021-02-15 14:30:00',0,2,9),
('Stefan','305-620-8341','2021-02-06 20:00:00',0,4,17),
('Elena','905-620-8341','2021-12-06 11:00:00',0,2,18),
('Gilbert','605-620-8341','2021-02-07 13:30:00',0,2,2),
('Bonnie','555-620-8341','2021-02-08 10:00:00',0,2,4),
('David','405-620-8341','2022-03-03 15:15:00',0,2,11)
GO

-- Table Stock
CREATE TABLE Stock (
	StockId int PRIMARY KEY IDENTITY(1,1),
	IngredientID int NOT NULL,
	[Name] varchar(200) NULL,
	CalculationUnit varchar(50) NOT NULL,
	Quantity int NOT NULL
)
GO
-- Insert data
INSERT INTO Stock VALUES 
(2,'Mushroom','Kg',30),
(3,'Beef','Kg',20)
GO

-- Table Accounts
CREATE TABLE Accounts
(
	Username varchar(30) PRIMARY KEY,
	[Password] varchar(100) NOT NULL,
	[Role] varchar(255) NOT NULL
)
GO

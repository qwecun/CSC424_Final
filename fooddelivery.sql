create database FoodDelivery;
use FoodDelivery;

create table Login(
User_ID char(4) primary key,
User_name varchar(20),
User_Password char(20));

create table Customer(
User_ID char(4) primary key,
First_Name char(15),
Last_Name char(15),
Cust_Email varchar(50),
Address char(50),
City char(10),
State char(2),
Zip char(5),
Phone_Num char(10));


create table Food_Order(
Order_ID char(4) primary key,
Food_Name char(15),
Quantity char(4),
User_ID char(4));

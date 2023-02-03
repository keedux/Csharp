import mysql.connector

database = mysql.connector.connect(
    host = "localhost",
    user = "root",
    password = "",
)
mycursor = database.cursor()
mycursor.execute("CREATE DATABASE IF NOT EXISTS f1teams")
print("Database Created")

mycursor.execute("USE f1teams")
mycursor.execute("CREATE TABLE IF NOT EXISTS tblgrades(Team varchar(25), Driver varchar(25), DriverPoints int, ConstructorPoints int, FastestLap bool, CONSTRAINT pk_Team PRIMARY KEY(Team))")
print("Table Created")


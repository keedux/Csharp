import mysql.connector
mydb = mysql.connector.connect(
    host = "localhost",
    user = "root",
    password = "",
)

mycursor = mydb.cursor()
mycursor.execute("CREATE DATABASE IF NOT EXISTS grades")
print("Database Created")

mycursor.execute("USE grades")
mycursor.execute("CREATE TABLE IF NOT EXISTS tblgrades(candidatenum int, paper1 int, paper2 int, finalgrade char, CONSTRAINT pk_candidatenum PRIMARY KEY(candidatenum))")
print("Table Created")


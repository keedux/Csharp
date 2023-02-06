import time
def write_config(host, username, password, database):
    config = {
        'host': host,
        'username': username,
        'password': password,
        'database': database
    }
    with open("F1Teams/bin/Debug/config.txt", 'w') as file:
        for key, value in config.items():
            file.write(f"{key}={value}\n")

if __name__ == '__main__':
    host = input("Enter host: ")
    username = input("Enter username: ")
    password = input("Enter password: ")
    database = input("Enter database: ")
    write_config(host, username, password, database)
else:
    print("Failed to make config.txt")
    time.sleep(3)
print("")
print("---------------------------------------------------")
print("config created. please restart F1 Teams Application")
print("---------------------------------------------------")

print("")

time.sleep(3)

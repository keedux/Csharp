import time
def write_config(host, username, password, database):
    config = {
        'host': host,
        'username': username,
        'password': password,
        'database': database
    }
    with open("config.txt", 'w') as file:
        for key, value in config.items():
            file.write(f"{key}={value}\n")

if __name__ == '__main__':
    host = input("Enter host: ")
    username = input("Enter username: ")
    password = input("Enter password: ")
    database = input("Enter database: ")
    write_config(host, username, password, database)
print("")
print("--------------------------------------------------")
print("config created. please restart Grades Application")
print("--------------------------------------------------")

print("")

time.sleep(3)

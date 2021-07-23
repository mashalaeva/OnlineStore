INSERT INTO public."Users"(
	"Id", "Name", "Surname", 
	"PhoneNumber", "Login", "Email", 
	"Password", "Role", "Address")
VALUES (1, 'Иван', 'Иванов', '+79151112233', 'vanya', 'ivan@example.com', 'a1111', 1, 'Адрес'),
       (2, 'Петр', 'Петров', '+79154442233', 'petr', 'petr@example.com', 'b2222', 2, 'Адрес'),
       (3, 'Екатерина', 'Смирнова', '+79154442234', 'katya', 'eka@example.com', 'c3333', 2, 'Адрес'),
       (4, 'Валентина', 'Архипова', '+79154442235', 'vaLenTiNa', 'val@example.com', 'd4444', 2, 'Адрес');
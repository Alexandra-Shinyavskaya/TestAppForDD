# Тестовое задание для Digital Design

## Задание 1.

    1. SELECT name, salary  FROM employee WHERE salary = (SELECT max(salary) FROM employee);

    2. WITH RECURSIVE chief_tree AS (SELECT id, chief_id, 1 AS depth FROM employee WHERE chief_id IS NULL UNION ALL SELECT e.id, e.chief_id, mt.depth + 1 AS depth FROM employee e JOIN chief_tree mt on mt.id=e.chief_id);
    SELECT max(depth) as max_depth FROM chief_tree;

    3. SELECT e.total, department.name FROM department JOIN (SELECT employee.department_id, sum(employee.salary) as total FROM employee GROUP BY employee.department_id ) as e ON department.id=e.department_id GROUP BY department.name HAVING e.total=(SELECT MAX(total) as total FROM (SELECT employee.department_id, sum(employee.salary) as total FROM employee GROUP BY employee.department_id) as e) ;

    4. SELECT * FROM employee WHERE employee.name LIKE "р%н";

## Задание 2
Консольное приложение, которое на вход принимает файл с текстом, а на выходе создает текстовый файл с перечислением всех уникальных слов встречающихся в тексте и количеством их употреблений, отсортированных в порядке убывания количества употреблений.
Для начала работы программы необходимо проинициализировать в коде переменные input и output путем файлов для чтения и записи соответственно

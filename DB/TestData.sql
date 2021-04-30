USE ITSkillsDB
GO

INSERT INTO Professions
VALUES
('Programmer'),
('UI Designer')
GO

INSERT INTO Skills
VALUES
('C++', 1),
('C#', 1),
('.NET CORE', 1),
('XAML', 2),
('Design', 2),
('Photoshop', 2),
('Delphi', 1)
GO

INSERT INTO Employees
VALUES
('John', 'Smith', NULL, '1980-12-10', 1),
('Mary', 'Johnson', NULL, '1981-03-05', 2),
('Alex', 'Johnson', NULL, '1980-04-25', 1)
GO

INSERT INTO EmployeesSkills
VALUES
(1, 2),
(2, 6),
(3, 3),
(3, 5)
GO
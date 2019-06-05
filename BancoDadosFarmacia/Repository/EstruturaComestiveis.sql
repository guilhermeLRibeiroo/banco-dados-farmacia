DROP TABLE produtos_comestiveis;

CREATE TABLE produtos_comestiveis 
(
	id INT PRIMARY KEY IDENTITY(1,1),
	nome VARCHAR(100),
	marca VARCHAR(100),
	valor DECIMAL(18,2),
	quantidade INT,
	data_vencimento DATETIME2
);
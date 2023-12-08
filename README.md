# CreditAPI

Criação das tabelas em SQL:

CREATE TABLE Cliente (
    CPF CHAR(11) PRIMARY KEY,
    Nome VARCHAR(100),
    UF CHAR(2),
    Celular VARCHAR(20)
);

CREATE TABLE Financiamento (
    IdFinanciamento INT PRIMARY KEY,
    CPF CHAR(11) FOREIGN KEY REFERENCES Cliente(CPF),
    TipoFinanciamento VARCHAR(50),
    ValorTotal DECIMAL(18, 2),
    DataUltimoVencimento DATE
);

CREATE TABLE Parcela (
    IdParcela INT PRIMARY KEY,
    IdFinanciamento INT FOREIGN KEY REFERENCES Financiamento(IdFinanciamento),
    NumeroParcela INT,
    ValorParcela DECIMAL(18, 2),
    DataVencimento DATE,
    DataPagamento DATE
);

Inserção de alguns dados:

INSERT INTO Cliente VALUES ('12345678910', 'Cliente 1', 'SP', '123456789');
INSERT INTO Cliente VALUES ('10987654321', 'Cliente 2', 'SP', '987654321');

INSERT INTO Financiamento VALUES (1, '12345678901', 'Financiamento Pessoal', 5000.00, '2023-12-31');
INSERT INTO Financiamento VALUES (2, '23456789012', 'Financiamento Empresarial', 8000.00, '2023-11-30');

INSERT INTO Parcela VALUES (1, 1, 1, 1000.00, '2023-01-15', '2023-01-10');
INSERT INTO Parcela VALUES (2, 1, 2, 2000.00, '2023-02-15', NULL);
INSERT INTO Parcela VALUES (3, 1, 3, 3000.00, '2023-03-15', '2023-03-10');

Listar todos os clientes do estado de SP que possuem mais de 60% das parcelas pagas:

SELECT c.Nome, c.CPF
FROM Cliente c
JOIN Financiamento f ON c.CPF = f.CPF
JOIN Parcela p ON f.IdFinanciamento = p.IdFinanciamento
WHERE c.UF = 'SP'
GROUP BY c.Nome, c.CPF
HAVING AVG(CASE WHEN p.DataPagamento IS NOT NULL THEN 1 ELSE 0 END) > 0.6;

Listar os primeiros quatro clientes que possuem alguma parcela com mais de cinco dia sem atraso:

SELECT TOP 4 c.Nome, c.CPF
FROM Cliente c
JOIN Financiamento f ON c.CPF = f.CPF
JOIN Parcela p ON f.IdFinanciamento = p.IdFinanciamento
WHERE p.DataVencimento > GETDATE() AND p.DataPagamento IS NULL
ORDER BY p.DataVencimento;

-------------------------------------------------------------------------------------------------------------------------------

Descreva sobre microsserviços:

Microsserviços possuem uma organização de arquitetura de software onde podemos dividir uma aplicação em diversos serviços, cada um 
realizando uma parte de uma tarefa em específico, melhorando a agilidade no desenvolvimento. Podemos exemplificar a explicação em torno do uso de API's que são os meios
de comunicações entree esses serviços

Basicamente sendo cada componente independente e podendo ser atribuidos a containers, a aplicaçãoe desenvolvimento ganham uma maior flexibilidade e podem ser desenvolvidas em diferentes linguagens.

   

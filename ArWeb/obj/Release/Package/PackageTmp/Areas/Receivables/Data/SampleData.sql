
--accounts 
insert into ArAccounts([Name],[Landline],[Email],[Mobile],[Company],[Address],[Remarks],[ArAccStatusId]) values
('John Doe' , '(082) 555 0100', 'johndoe@gmail.com', '0922 656 9877', 'Acer Ph Inc','Makati','',1),
('Mark Cruz', '(082) 333 1212', 'markCruz@gmail.com', '0911 085 8455','NewCompany','Manila','',1),
('Mary Lee' , '(082) 555 0100', 'marylee@gmail.com', '0927 898 8822','Microsoft','Makati','',1),
('Tony Stark', '(082) 222 2525', 'tonystark@gmail.com', '0926 333 3233','','Davao','',1),
('Peter Parker', '(082) 777 8989', 'peterparker@gmail.com', '0921 112 3238','','Davao','',1);

-- account credits
insert into ArAccntCredits([ArAccountId],[DtCredit],[CreditLimit],[OverLimitAllowed],[CreditWarning],[ApprovedBy],[ArCreditStatusId]) values
(2, '11/21/2020', 50000, 10000, 40000, 'admin', 1),
(3, '11/21/2020', 50000, 10000, 40000, 'admin', 1),
(4, '11/20/2020', 60000, 10000, 50000, 'admin', 1),
(5, '11/20/2020', 70000, 20000, 60000, 'admin', 1);


-- account terms
insert into ArAccntTerms([ArAccountId],[dtTerm],[NoOfDays],[Remarks],[ApprovedBy],[ArAccntTermStatusId]) values
(2, '11/21/2020', 15, null, 'admin', 1),
(3, '11/21/2020', 15, null, 'admin', 1),
(4, '11/21/2020', 15, null, 'admin', 1),
(5, '11/21/2020', 15, null, 'admin', 1);

--transactions
insert into ArTransactions([ArAccountId],[InvoiceId],[DtInvoice],[Description],[DtEncoded],[DtDue],[Amount],[Interval],[IsRepeating],[Remarks],[ArTransStatusId],[ArCategoryId],[DtService], [DtServiceTo], [PrevRef], [NextRef], [InvoiceRef], [RepeatNo] ) values
(2, '101', '02/21/2021', 'Invoice 101', '02/21/2021', '03/15/2021', 50000,  0, 0, null, 2, 1, '02/18/2021', '02/25/2021',0,0, 'INV001', null),
(3, '102', '02/18/2021', 'Invoice 102', '02/20/2021', '03/19/2021', 70000,  0, 0, null, 2, 1, '02/10/2021', '02/14/2021',0,0, 'INV002', null),
(4, '103', '02/15/2021', 'Invoice 103', '02/19/2021', '02/25/2021', 80000,  0, 0, null, 1, 1, '02/15/2021', '02/16/2021',0,0, NULL, null),
(5, '104', '02/10/2021', 'Invoice 104', '02/20/2021', '03/12/2021', 50000, 30, 1, null, 1, 1, '02/10/2021', '02/12/2021',0,0, NULL, null),
(6, '106', '02/12/2021', 'Invoice 105', '02/19/2021', '02/24/2021', 45000, 15, 1, null, 3, 1, '02/12/2021', '02/15/2021',0,0, NULL, null);

-- payments
insert into ArPayments([DtPayment],[Amount],[Remarks],[Reference],[ArAccountId],[ArPaymentTypeId]) values
('02/21/2021',  5000, null, null, 2, 1),
('02/22/2021',  5000, null, null, 2, 1),
('02/21/2021', 15000, null, null, 3, 1),
('02/21/2021', 12000, null, null, 4, 1);

-- transaction payments
insert into ArTransPayments([ArTransactionId],[ArPaymentId]) values 
(1,1),
(1,2),
(2,3),
(3,4);


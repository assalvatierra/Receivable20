insert into ArTransStatus([Status]) values
('New'),('Approved'),('Reminder Sent'),('Payment'),('Settlement'),('Closed');

insert into ArAccStatus([Status]) values
('Active'),('Inactive'),('OnHold');

insert into ArPaymentTypes([Type]) values
('Cash'),('Check'),('Bank'),('PO'),('Others');

insert into ArActionItems([Action],[Remarks],[SortNo]) values
('New Bill','',1),('Bill Approved','',2),('Bill Sent','',3),('Bill Received','',4),('Bill Payment','',5), ('Bill Settled','',6),('Bill Closed','',6),
('1st Reminder Sent','',11),('2nd Reminder Sent','',12),('2nd Reminder Sent','',13);

insert into ArAccounts([Name],[Landline],[Email],[Mobile],[Company],[Address],[Remarks],[ArAccStatusId]) values
('< New Account >', null, 'NA', 'NA', null, null, null, 1);

insert into ArCategories([Name],[Remarks],[SortNo]) values
('Others', '', 100);

insert into ArCreditStatus([Status]) values ('Active'),('Pending'),('Expired');

insert into ArAccntTermStatus([Status]) values ('Active'),('Pending'),('Expired');




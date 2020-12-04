insert into ArTransStatus([Status]) values
('New'),('Approved'),('Sent'),('Payment'),('Settlement'),('Closed');

insert into ArAccStatus([Status]) values
('Active'),('Inactive'),('OnHold');

insert into ArPaymentTypes([Type]) values
('Cash'),('Check'),('Bank'),('PO'),('Others');

insert into ArActionItems([Action],[Remarks],[SortNo]) values
('New Bill','',1),('Bill Sent','',2),('Bill Received','',3),
('1st Reminder','',4),('2nd Reminder','',5),('Paid','',6);

insert into ArAccounts([Name],[Landline],[Email],[Mobile],[Company],[Address],[Remarks],[ArAccStatusId]) values
('< New Account >', null, 'NA', 'NA', null, null, null, 1);

insert into ArCategories([Name],[Remarks],[SortNo]) values
('Others', '', 100);

insert into ArCreditStatus([Status]) values ('Active'),('Pending'),('Expired');

insert into ArAccntTermStatus([Status]) values ('Active'),('Pending'),('Expired');




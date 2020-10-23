insert into ArTransStatus([Status]) values
('New'),('Ongoing'),('Close');

insert into ArAccStatus([Status]) values
('Active'),('Inactive'),('OnHold');

insert into ArPaymentTypes([Type]) values
('Cash'),('Check'),('Bank'),('PO'),('Others');

insert into ArActionItems([Action],[Remarks],[SortNo]) values
('New Bill','',1),('Bill Sent','',2),('Bill Received','',3),
('1st Reminder','',4),('2nd Reminder','',5),('Paid','',6);

insert into ArAccounts([Name],[Landline],[Email],[Mobile],[Company],[Address],[Remarks],[ArAccStatusId]) values
('< New Account >', null, 'NA', 'NA', null, null, null, 1);

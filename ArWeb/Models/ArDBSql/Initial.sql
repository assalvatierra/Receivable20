insert into ArTransStatus([Status]) values
('New'),('Ongoing'),('Close');

insert into ArAccStatus([Status]) values
('Active'),('Inactive'),('OnHold');

insert into ArPaymentType([Type]) values
('Cash'),('Check'),('Bank'),('PO'),('Others');

insert into ArActionItem([Action],[Remarks],[SortNo]) values
('New Bill','',1),('Bill Sent','',2),('Bill Received','',3),
('1st Reminder','',4),('2nd Reminder','',5),('Paid','',6);
select 
	b.Name,
	b.Company, 
	x.InvCnt,
	x.AcntAmount
from 
(
select 
	max(a.ArAccountId) AccntId,
	count(a.InvoiceId) InvCnt,
	count(a.Amount) AcntAmount,
	count(a.ArTransStatusId) ArStatus
from 
	ArTransactions a
group by a.ArAccountId
) x
left outer join ArAccounts b on x.AccntId = b.Id

order by x.AccntId
;

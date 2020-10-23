select 
	a.InvoiceId,
	a.DtInvoice,
	b.Name,
	b.Company,
	a.Description,
	a.DtDue, 
	a.Amount, 
	a.Remarks,
	c.Status
from ArTransactions a
left outer join ArAccounts b on a.ArAccountId = b.Id
left outer join ArTransStatus c on a.ArTransStatusId = c.Id

order by a.ArAccountId, a.DtInvoice
;

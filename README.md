# Programma di un'ipotetica Banca
In primo luogo troviamo una pagina semplice di accesso o iscrizione che ti fa inserire i dati e li valida per poi, in caso di iscrizione, inserirli in una lista nella classe di tipo banca precedentemente istanziata: Si poteva anche inserire i dati in un database o in un file csv, ma per lo scopo per cui era destinato non aveva senso mantenere dei dati permanenti(Scopo meramente scolastico)
Si viene poi rimandati a una pagina dove esce subito un PopUp che ci segnala il codice per riacedere: in caso è importante segnarselo. In questa pagina abbiamo 3 tipi di PopUp. 
1. Il primo è quello che abbiamo appena visto. Relativamente semplice con una scritta e un button. Nel codice è chiamato semplicemente "PopUp".
2. Il secondo tipo è già più complesso ed è quello utilizzato per il deposito o il prelivo di soldi. Sfrutta un mtodo async per aprire il Popup e per comunicare i dati dal Popup alla home, usando il metodo close() per chiudersi, si utilizzano delle properties all'interno della classe banca: lo si fa sia per comunicare l'importo che quando cambiare il valore testo della Label del saldo totale. Per il prelievo viene effettuato un semplice controllo in più per verificare che l'importo non superi il saldo disponibile
3. E' simile al secondo per alcuni versi, ma questa volta abbiamo due cambio da compilare e da verifica: si tratta del Popup per inviare del denaro ad un altro account. Si effettua quindi un mix tra quello che si fa nel primo e nel secondo Popup sfruttando la lista degli utenti contenuta sempre nella classe di tipo banca

I Popup non sono fatti utilizzando l'alert messo a disposizione dalla Microsoft come strumento, ma utilizzando la classe **PopUp**.
Infine ci sono due opzioni: log-out e chiudi account . Il primo torna semplicemente alla Main Page, ovvero dove si può fare l'accesso, mentre il secondo, oltre a tornare alla Main Page, cancella anche l'account corrente dalla lista degli account contenuta nella classe di tipo banca.

Tutte le transazioni sono registrate all'interno di due liste: una per i movimenti in uscita e una per i movimenti in entrata.

# OpenDIPS-FHIR-cs-cli
Open DIPS FHIR api c# CLI test.
* Register at http://open.dips.no.
* Apply for product subscription.
* Clone repo.
* Copy and paste subscription key from 'Primary key' from desired product under 'Subscriptions', into <b>DipsSubscriptionKey</b>.
* Perform Oauth 2.0 authentication, see description at https://open.dips.no/getting-started. Copy and paste access token into <b>bearerToken</b>. Currently lasts for 1 hour.
* dotnet run in folder <b>src</b>.

## Expected output: <br>
Total patients: 50, page count: 50.
- Entry  0: https://api.dips.no/fhir/patient/cdp2007243
-           cdp2007243 Testp Grpbest, Pasient 1
- Entry  1: https://api.dips.no/fhir/patient/cdp2007245
-           cdp2007245 Testp Grpbest, Pasient 2
- Entry  2: https://api.dips.no/fhir/patient/cdp2007247
-           cdp2007247 Testp Grpbest, Pasient 3

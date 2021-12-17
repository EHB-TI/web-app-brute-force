# Evaluatiecriteria ivm beveiliging tegen typische web vulnerabilities
- [x] Er wordt geen gebruik gemaakt van kwetsbare componenten - geen van de runtime dependencies hebben een High of Critical Severity CVSS score; 
- [ ] Alle formulieren een CSRF token bevatten dat server-side gecontroleerd wordt;
- [ ] De sessie afloopt na verloop van tijd;
- [x] XSS protection
- [ ] Zet de X-Frame-Options header om clickjacking te vermijden of vermijd het met frame-ancestors in je CSP;
- [ ] Definieer een strikte CSP voor je toepassing
- [ ] Laad geen overbodige code, dit vergroot enkel de 'attack surface' van je toepassing;
- [ ] X-Content-Type-Options: nosniff wordt gebruikt om MIME sniffing tegen te gaan. 

----------------------------------------------------------------------------
# Evaluatiecriteria ivm HTTPS
- [x] HTTPS only
- [x] Certificate chain waarvan de root voorkomt in de standaard trust store
- [x] Je domein of domeinen krijgen minstens een A score bij de SSL Labs server test
- [x] Iedere respons bevat een Strict-Transport-Security header;
- [ ] CAA DNS Resource Records voor je domein of domeinen.
- [X] Je domein of domeinen staan in de HSTS preload list of wachten op toevoeging;
--------------------------------------------------------------------------------------------------------------------------------------------------------
# Evaluatiecriteria ivm aanmelden 
- [x] Een gebruiker moet zich ook kunnen afmelden
- [x] Een applicatie geeft ten alle tijde duidelijk aan of de gebruiker al dan niet aangemeld is
- [x] Na aanmelden kan de gebruiker zijn of haar gegevens opvragen
- [ ] Een gebruiker mag zich pas kunnen aanmelden als hij of zij controle over een email adres opgegeven tijdens registratie heeft aangetoond
--------------------------------------------------------------------------------------------------------------------------------------------------------
# Evaluatiecriteria ivm wachtwoorden
#### bij registratie dient de gebruiker:
- [x] Te kunnen kopiëren uit een password manager en in een password veld van de registratiepagina plakken
- [x] Een gebruiker moet zich ook kunnen afmelden
- [ ] Verplicht om  een wachtwoord te kiezen van minstens 8 karakters
- [x] Een zeer lang wachtwoord te kunnen kiezen met lengte minstens 64 karakters
- [x] Elk 'printable' ASCII karakter te kunnen opnemen in het wachtwoord
- [ ] Verplicht te worden een wachtwoord te kiezen dat niet vaak voorkomt 
#### bij aanmelden dient de gebruiker:
- [x] Te kunnen kopiëren uit een password manager en in een password veld van de aanmeldingspagina plakken
#### De toepassing verdedigt zich tegen brute force en credential stuffing attacks:
- [ ] Bij herhaalde mislukte pogingen verhoogt het tijdsinterval tussen pogingen exponentieel
- [ ] MFA
- [ ] Bij herhaalde mislukte pogingen wordt het account geblokkeerd
--------------------------------------------------------------------------------------------------------------------------------------------------------
# Evaluatiecriteria ivm privacy Cookie Directive:
- [ ] Gebruikers worden ingelicht over de gebruikte cookies, welke informatie wordt verzameld  en waarvoor ze dient;
- [ ] Gebruikers toestemming geven voor deze trackers;
--------------------------------------------------------------------------------------------------------------------------------------------------------
# Evaluatiecriteria ivm privacy
#### Privacyverklaring: 
De privacyverklaring dient minstens volgende gegevens te bevatten:
- [ ] De identiteit en de contactgegevens (bijv. naam, adres, …) van de verwerkingsverantwoordelijke
- [ ] Wanneer de persoonsgegevens worden doorgestuurd, de ontvangers of categorieën van ontvangers van de persoonsgegevens (bijv. een website ontwikkelaar, het sociaal secretariaat, …);
- [ ] De bewaringstermijn van de persoonsgegevens, of indien deze niet vast bepaald is, de criteria die deze bewaringstermijn bepalen (bijv. termijnen opgelegd door boekhoudwetgeving, … );
- [ ] De precieze rechten van betrokkene. Minimaal dien je hier dus de rechten vastgelegd door de AVG en van toepassing op jouw app uit te leggen aan de gebruiker/betrokkene;
- [ ] Indien toestemming als rechtsgrond wordt gebruikt, dat de betrokkene steeds het recht heeft die toestemming in te trekken;
- [ ] Dat de betrokkene het recht heeft klacht in te dienen bij een toezichthoudende autoriteit;
- [ ] Of de verstrekking van persoonsgegevens een wettelijke of contractuele verplichting is, of noodzakelijk en of de betrokkene verplicht is de persoonsgegevens te verstrekken en wat de mogelijke gevolgen zijn wanneer deze gegevens niet worden verstrekt;
- [ ] Het bestaan van geautomatiseerde besluitvorming en nuttige informatie over de onderliggende logica en het belang en de gevolgen van die verwerking voor de betrokkene;
- [ ] De (categorieën van) gegevens en de bron waar de persoonsgegevens vandaan komen, indien U de persoonsgegevens niet van de betrokkene rechtstreeks heeft ontvangen.
####  Verwerkingsregister:
Het verwerkingsregister bevat volgende gegevens:
- [ ] de identiteit en de contactgegevens (bijv. naam, adres, …) van de verwerkingsverantwoordelijke;
- [ ] per verwerking de verwerkingsdoeleinden;
- [ ] per verwerking de categoriën van persoonsgegevens en betrokkenen;
- [ ] wanneer de persoonsgegevens worden doorgestuurd, de ontvangers van de persoonsgegevens;
- [ ] de bewaringstermijn van de persoonsgegevens;
- [ ] een algemene beschrijving van de beveiligingsmaatregelen.
####  Evaluatiecriteria ivm privacy Rechten van betrokkenen
De toepassing maakt het mogelijk voor betrokkenen om hun rechten uit te oefenen.
- [x] Recht op inzage
- [x] Recht op rectificatie en wissen van gegevens
- [ ] Recht op beperking van de verwerking van gegevens
- [ ] Recht op gegevensoverdraagbaarheid
- [ ] Recht om niet aan geautomatiseerde besluitvorming onderworpen te worden
--------------------------------------------------------------------------------------------------------------------------------------------------------
# DAST testing:
Hiervoor hebben we gekozen voor de tool Owasp Zed attack proxy (zap):
We hebben volgende config/plugin gebruikt:

| Plugin                                     | Strength |
|--------------------------------------------|----------|
| Path Traversal                             | Insane   |
| Remote File Inclusion                      | Insane   |
| External Redirect                          | Insane   |
| Server Side Include                        | Insane   |
| Source Code Disclosure - /WEB-INF folder   | Insane   |
| Cross Site Scripting (Reflected)           | Insane   |
| Cross Site Scripting (Persistent) - Prime  | Insane   |
| Cross Site Scripting (Persistent) - Spider | Insane   |
| Cross Site Scripting (Persistent)          | Insane   |
| SQL Injection                              | Insane   |
| Server Side Code Injection                 | Insane   |
| Remote OS Command Injection                | Insane   |
| Directory Browsing                         | Insane   |
| Buffer Overflow                            | Insane   |
| CRLF Injection	                           | Insane   |
| Parameter Tampering	                       | Insane   |
| ELMAH Information Leak                     | Insane   |
| .htaccess Information Leak                 | Insane   |
| Script Active Scan Rules	                 | Insane   |
| Cross Site Scripting (DOM Based)           | Insane   |
| SOAP Action Spoofing                       | Insane   |
| SOAP XML Injection.                        | Insane   |



## Resultaten:

# ZAP Scanning Report


## Summary of Alerts

| Risk Level | Number of Alerts |
| --- | --- |
| High | 1 |
| Medium | 3 |
| Low | 12 |
| Informational | 8 |




## Alerts

| Name | Risk Level | Number of Instances |
| --- | --- | --- |
| Remote OS Command Injection | High | 9 |
| CSP: Wildcard Directive | Medium | 89 |
| CSP: script-src unsafe-inline | Medium | 89 |
| CSP: style-src unsafe-inline | Medium | 89 |
| A Server Error response code was returned by the server | Low | 1 |
| Absence of Anti-CSRF Tokens | Low | 13 |
| Cookie Without Secure Flag | Low | 2 |
| Cookie with SameSite Attribute None | Low | 4 |
| Cookie without SameSite Attribute | Low | 4 |
| Cross-Domain JavaScript Source File Inclusion | Low | 88 |
| Incomplete or No Cache-control Header Set | Low | 88 |
| Server Leaks Information via "X-Powered-By" HTTP Response Header Field(s) | Low | 262 |
| Server Leaks Information via 'X-Powered-By' HTTP Response Header Field(s)(script) | Low | 262 |
| Server Leaks Version Information via 'Server' HTTP Response Header Field(script) | Low | 262 |
| Timestamp Disclosure - Unix | Low | 23 |
| Unexpected Content-Type was returned | Low | 4297 |
| A Client Error response code was returned by the server | Informational | 7 |
| An upload form appeared! (script) | Informational | 8 |
| Base64-encoded string found (script) | Informational | 77 |
| Email addresses (script) | Informational | 8 |
| Information Disclosure - Sensitive Information in URL | Informational | 23 |
| Information Disclosure - Suspicious Comments | Informational | 3 |
| Information Exposure Through HTML Comments (script) | Informational | 88 |
| SameSite cookie attribute protection used | Informational | 18 |


## Alert Detail

### [ Remote OS Command Injection ](https://www.zaproxy.org/docs/alerts/90020/)

##### High (Medium)

### Description

Attack technique used for unauthorized execution of operating system commands. This attack is possible when an application accepts untrusted input to build operating system commands in an insecure manner involving improper data sanitization, and/or improper calling of external programs.

* URL: https://ehikebe.azurewebsites.net/%3Fname../../../../../../../../../../../../../../../../Windows/system.ini=abc%2522%257Ctimeout%2520/T%252015
  * Method: `GET`
  * Parameter: `name../../../../../../../../../../../../../../../../Windows/system.ini`
  * Attack: `abc"|timeout /T 15`
  * Evidence: ``
* URL: https://ehikebe.azurewebsites.net/%3Fname../../../../../../../../../../../../../../../../Windows/system.iniabc';sleep$kn%252015;'=abc
  * Method: `GET`
  * Parameter: `name../../../../../../../../../../../../../../../../Windows/system.ini`
  * Attack: `abc';sleep$kn 15;'`
  * Evidence: ``
* URL: https://ehikebe.azurewebsites.net/%3Fname=abc&timeout%2520/T%252015
  * Method: `GET`
  * Parameter: `name`
  * Attack: `abc&timeout /T 15`
  * Evidence: ``
* URL: https://ehikebe.azurewebsites.net/%3Fname=abc;sleep%252015;
  * Method: `GET`
  * Parameter: `name`
  * Attack: `abc;sleep 15;`
  * Evidence: ``

### Solution

If at all possible, use library calls rather than external processes to recreate the desired functionality.

Run your code in a "jail" or similar sandbox environment that enforces strict boundaries between the process and the operating system. This may effectively restrict which files can be accessed in a particular directory or which commands can be executed by your software.

OS-level examples include the Unix chroot jail, AppArmor, and SELinux. In general, managed code may provide some protection. For example, java.io.FilePermission in the Java SecurityManager allows you to specify restrictions on file operations.
This may not be a feasible solution, and it only limits the impact to the operating system; the rest of your application may still be subject to compromise.

For any data that will be used to generate a command to be executed, keep as much of that data out of external control as possible. For example, in web applications, this may require storing the command locally in the session's state instead of sending it out to the client in a hidden form field.

Use a vetted library or framework that does not allow this weakness to occur or provides constructs that make this weakness easier to avoid.

For example, consider using the ESAPI Encoding control or a similar tool, library, or framework. These will help the programmer encode outputs in a manner less prone to error.

If you need to use dynamically-generated query strings or commands in spite of the risk, properly quote arguments and escape any special characters within those arguments. The most conservative approach is to escape or filter all characters that do not pass an extremely strict allow list (such as everything that is not alphanumeric or white space). If some special characters are still needed, such as white space, wrap each argument in quotes after the escaping/filtering step. Be careful of argument injection.

If the program to be executed allows arguments to be specified within an input file or from standard input, then consider using that mode to pass arguments instead of the command line.

If available, use structured mechanisms that automatically enforce the separation between data and code. These mechanisms may be able to provide the relevant quoting, encoding, and validation automatically, instead of relying on the developer to provide this capability at every point where output is generated.

Some languages offer multiple functions that can be used to invoke commands. Where possible, identify any function that invokes a command shell using a single string, and replace it with a function that requires individual arguments. These functions typically perform appropriate quoting and filtering of arguments. For example, in C, the system() function accepts a string that contains the entire command to be executed, whereas execl(), execve(), and others require an array of strings, one for each argument. In Windows, CreateProcess() only accepts one command at a time. In Perl, if system() is provided with an array of arguments, then it will quote each of the arguments.

Assume all input is malicious. Use an "accept known good" input validation strategy, i.e., use an allow list of acceptable inputs that strictly conform to specifications. Reject any input that does not strictly conform to specifications, or transform it into something that does. Do not rely exclusively on looking for malicious or malformed inputs (i.e., do not rely on a deny list). However, deny lists can be useful for detecting potential attacks or determining which inputs are so malformed that they should be rejected outright.

When performing input validation, consider all potentially relevant properties, including length, type of input, the full range of acceptable values, missing or extra inputs, syntax, consistency across related fields, and conformance to business rules. As an example of business rule logic, "boat" may be syntactically valid because it only contains alphanumeric characters, but it is not valid if you are expecting colors such as "red" or "blue."

When constructing OS command strings, use stringent allow lists that limit the character set based on the expected value of the parameter in the request. This will indirectly limit the scope of an attack, but this technique is less important than proper output encoding and escaping.

Note that proper output encoding, escaping, and quoting is the most effective solution for preventing OS command injection, although input validation may provide some defense-in-depth. This is because it effectively limits what will appear in output. Input validation will not always prevent OS command injection, especially if you are required to support free-form text fields that could contain arbitrary characters. For example, when invoking a mail program, you might need to allow the subject field to contain otherwise-dangerous inputs like ";" and ">" characters, which would need to be escaped or otherwise handled. In this case, stripping the character might reduce the risk of OS command injection, but it would produce incorrect behavior because the subject field would not be recorded as the user intended. This might seem to be a minor inconvenience, but it could be more important when the program relies on well-structured subject lines in order to pass messages to other components.

Even if you make a mistake in your validation (such as forgetting one out of 100 input fields), appropriate encoding is still likely to protect you from injection-based attacks. As long as it is not done in isolation, input validation is still a useful technique, since it may significantly reduce your attack surface, allow you to detect some attacks, and provide other security benefits that proper encoding does not address.

### Reference


* [ http://cwe.mitre.org/data/definitions/78.html ](http://cwe.mitre.org/data/definitions/78.html)
* [ https://owasp.org/www-community/attacks/Command_Injection ](https://owasp.org/www-community/attacks/Command_Injection)


#### CWE Id: [ 78 ](https://cwe.mitre.org/data/definitions/78.html)


#### WASC Id: 31

#### Source ID: 1

### [ CSP: Wildcard Directive ](https://www.zaproxy.org/docs/alerts/10055/)



##### Medium (Medium)

### Description

The following directives either allow wildcard sources (or ancestors), are not defined, or are overly broadly defined: 
img-src, connects-src, frame-src, frame-ancestors, media-src, object-src, manifest-src, prefetch-src, form-action

The directive(s): frame-ancestors, form-action are among the directives that do not fallback to default-src, missing/excluding them is the same as allowing anything.

* URL: https://ehikebe.azurewebsites.net/
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `default-src 'self' https://images.unsplash.com data: https:;script-src 'self' 'unsafe-inline' 'unsafe-eval' https://ajax.aspnetcdn.com https://cdn.jsdelivr.net;style-src 'self' 'unsafe-inline' https://cdn.jsdelivr.net;font-src 'self' https://fonts.gstatic.com https://cdn.jsdelivr.net;block-all-mixed-content`
* URL: https://ehikebe.azurewebsites.net/%3Fname../../../../../../../../../../../../../../../../Windows/system.ini=abc
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `default-src 'self' https://images.unsplash.com data: https:;script-src 'self' 'unsafe-inline' 'unsafe-eval' https://ajax.aspnetcdn.com https://cdn.jsdelivr.net;style-src 'self' 'unsafe-inline' https://cdn.jsdelivr.net;font-src 'self' https://fonts.gstatic.com https://cdn.jsdelivr.net;block-all-mixed-content`
* URL: https://ehikebe.azurewebsites.net/%3Fname=abc
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `default-src 'self' https://images.unsplash.com data: https:;script-src 'self' 'unsafe-inline' 'unsafe-eval' https://ajax.aspnetcdn.com https://cdn.jsdelivr.net;style-src 'self' 'unsafe-inline' https://cdn.jsdelivr.net;font-src 'self' https://fonts.gstatic.com https://cdn.jsdelivr.net;block-all-mixed-content`


### Solution

Ensure that your web server, application server, load balancer, etc. is properly configured to set the Content-Security-Policy header.

### Reference


* [ http://www.w3.org/TR/CSP2/ ](http://www.w3.org/TR/CSP2/)
* [ http://www.w3.org/TR/CSP/ ](http://www.w3.org/TR/CSP/)
* [ http://caniuse.com/#search=content+security+policy ](http://caniuse.com/#search=content+security+policy)
* [ http://content-security-policy.com/ ](http://content-security-policy.com/)
* [ https://github.com/shapesecurity/salvation ](https://github.com/shapesecurity/salvation)
* [ https://developers.google.com/web/fundamentals/security/csp#policy_applies_to_a_wide_variety_of_resources ](https://developers.google.com/web/fundamentals/security/csp#policy_applies_to_a_wide_variety_of_resources)


#### CWE Id: [ 693 ](https://cwe.mitre.org/data/definitions/693.html)


#### WASC Id: 15

#### Source ID: 3

### [ CSP: script-src unsafe-inline ](https://www.zaproxy.org/docs/alerts/10055/)



##### Medium (Medium)

### Description

script-src includes unsafe-inline.

* URL: https://ehikebe.azurewebsites.net/
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `default-src 'self' https://images.unsplash.com data: https:;script-src 'self' 'unsafe-inline' 'unsafe-eval' https://ajax.aspnetcdn.com https://cdn.jsdelivr.net;style-src 'self' 'unsafe-inline' https://cdn.jsdelivr.net;font-src 'self' https://fonts.gstatic.com https://cdn.jsdelivr.net;block-all-mixed-content`
* URL: https://ehikebe.azurewebsites.net/%3Fname../../../../../../../../../../../../../../../../Windows/system.ini=abc
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `default-src 'self' https://images.unsplash.com data: https:;script-src 'self' 'unsafe-inline' 'unsafe-eval' https://ajax.aspnetcdn.com https://cdn.jsdelivr.net;style-src 'self' 'unsafe-inline' https://cdn.jsdelivr.net;font-src 'self' https://fonts.gstatic.com https://cdn.jsdelivr.net;block-all-mixed-content`
* URL: https://ehikebe.azurewebsites.net/%3Fname=abc
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `default-src 'self' https://images.unsplash.com data: https:;script-src 'self' 'unsafe-inline' 'unsafe-eval' https://ajax.aspnetcdn.com https://cdn.jsdelivr.net;style-src 'self' 'unsafe-inline' https://cdn.jsdelivr.net;font-src 'self' https://fonts.gstatic.com https://cdn.jsdelivr.net;block-all-mixed-content`


### Solution

Ensure that your web server, application server, load balancer, etc. is properly configured to set the Content-Security-Policy header.

### Reference


* [ http://www.w3.org/TR/CSP2/ ](http://www.w3.org/TR/CSP2/)
* [ http://www.w3.org/TR/CSP/ ](http://www.w3.org/TR/CSP/)
* [ http://caniuse.com/#search=content+security+policy ](http://caniuse.com/#search=content+security+policy)
* [ http://content-security-policy.com/ ](http://content-security-policy.com/)
* [ https://github.com/shapesecurity/salvation ](https://github.com/shapesecurity/salvation)
* [ https://developers.google.com/web/fundamentals/security/csp#policy_applies_to_a_wide_variety_of_resources ](https://developers.google.com/web/fundamentals/security/csp#policy_applies_to_a_wide_variety_of_resources)


#### CWE Id: [ 693 ](https://cwe.mitre.org/data/definitions/693.html)


#### WASC Id: 15

#### Source ID: 3

### [ CSP: style-src unsafe-inline ](https://www.zaproxy.org/docs/alerts/10055/)



##### Medium (Medium)

### Description

style-src includes unsafe-inline.

* URL: https://ehikebe.azurewebsites.net/
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `default-src 'self' https://images.unsplash.com data: https:;script-src 'self' 'unsafe-inline' 'unsafe-eval' https://ajax.aspnetcdn.com https://cdn.jsdelivr.net;style-src 'self' 'unsafe-inline' https://cdn.jsdelivr.net;font-src 'self' https://fonts.gstatic.com https://cdn.jsdelivr.net;block-all-mixed-content`
* URL: https://ehikebe.azurewebsites.net/%3Fname../../../../../../../../../../../../../../../../Windows/system.ini=abc
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `default-src 'self' https://images.unsplash.com data: https:;script-src 'self' 'unsafe-inline' 'unsafe-eval' https://ajax.aspnetcdn.com https://cdn.jsdelivr.net;style-src 'self' 'unsafe-inline' https://cdn.jsdelivr.net;font-src 'self' https://fonts.gstatic.com https://cdn.jsdelivr.net;block-all-mixed-content`
* URL: https://ehikebe.azurewebsites.net/%3Fname=abc
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `default-src 'self' https://images.unsplash.com data: https:;script-src 'self' 'unsafe-inline' 'unsafe-eval' https://ajax.aspnetcdn.com https://cdn.jsdelivr.net;style-src 'self' 'unsafe-inline' https://cdn.jsdelivr.net;font-src 'self' https://fonts.gstatic.com https://cdn.jsdelivr.net;block-all-mixed-content`


### Solution

Ensure that your web server, application server, load balancer, etc. is properly configured to set the Content-Security-Policy header.

### Reference


* [ http://www.w3.org/TR/CSP2/ ](http://www.w3.org/TR/CSP2/)
* [ http://www.w3.org/TR/CSP/ ](http://www.w3.org/TR/CSP/)
* [ http://caniuse.com/#search=content+security+policy ](http://caniuse.com/#search=content+security+policy)
* [ http://content-security-policy.com/ ](http://content-security-policy.com/)
* [ https://github.com/shapesecurity/salvation ](https://github.com/shapesecurity/salvation)
* [ https://developers.google.com/web/fundamentals/security/csp#policy_applies_to_a_wide_variety_of_resources ](https://developers.google.com/web/fundamentals/security/csp#policy_applies_to_a_wide_variety_of_resources)


#### CWE Id: [ 693 ](https://cwe.mitre.org/data/definitions/693.html)


#### WASC Id: 15

#### Source ID: 3

### [ Absence of Anti-CSRF Tokens ](https://www.zaproxy.org/docs/alerts/10202/)



##### Low (Medium)

### Description

No Anti-CSRF tokens were found in a HTML submission form.
A cross-site request forgery is an attack that involves forcing a victim to send an HTTP request to a target destination without their knowledge or intent in order to perform an action as the victim. The underlying cause is application functionality using predictable URL/form actions in a repeatable way. The nature of the attack is that CSRF exploits the trust that a web site has for a user. By contrast, cross-site scripting (XSS) exploits the trust that a user has for a web site. Like XSS, CSRF attacks are not necessarily cross-site, but they can be. Cross-site request forgery is also known as CSRF, XSRF, one-click attack, session riding, confused deputy, and sea surf.

CSRF attacks are effective in a number of situations, including:
    * The victim has an active session on the target site.
    * The victim is authenticated via HTTP auth on the target site.
    * The victim is on the same local network as the target site.

CSRF has primarily been used to perform an action against a target site using the victim's privileges, but recent techniques have been discovered to disclose information by gaining access to the response. The risk of information disclosure is dramatically increased when the target site is vulnerable to XSS, because XSS can be used as a platform for CSRF, allowing the attack to operate within the bounds of the same-origin policy.

* URL: https://ehikebe.azurewebsites.net/
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `<form id="contactForm" data-sb-form-api-token="API_TOKEN">`
* URL: https://ehikebe.azurewebsites.net/%3Fname../../../../../../../../../../../../../../../../Windows/system.ini=abc
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `<form id="contactForm" data-sb-form-api-token="API_TOKEN">`
* URL: https://ehikebe.azurewebsites.net/%3Fname=abc
  * Method: `GET`
  * Parameter: ``
  * Attack: ``


### Solution

Phase: Architecture and Design
Use a vetted library or framework that does not allow this weakness to occur or provides constructs that make this weakness easier to avoid.
For example, use anti-CSRF packages such as the OWASP CSRFGuard.

Phase: Implementation
Ensure that your application is free of cross-site scripting issues, because most CSRF defenses can be bypassed using attacker-controlled script.

Phase: Architecture and Design
Generate a unique nonce for each form, place the nonce into the form, and verify the nonce upon receipt of the form. Be sure that the nonce is not predictable (CWE-330).
Note that this can be bypassed using XSS.

Identify especially dangerous operations. When the user performs a dangerous operation, send a separate confirmation request to ensure that the user intended to perform that operation.
Note that this can be bypassed using XSS.

Use the ESAPI Session Management control.
This control includes a component for CSRF.

Do not use the GET method for any request that triggers a state change.

Phase: Implementation
Check the HTTP Referer header to see if the request originated from an expected page. This could break legitimate functionality, because users or proxies may have disabled sending the Referer for privacy reasons.

### Reference


* [ http://projects.webappsec.org/Cross-Site-Request-Forgery ](http://projects.webappsec.org/Cross-Site-Request-Forgery)
* [ http://cwe.mitre.org/data/definitions/352.html ](http://cwe.mitre.org/data/definitions/352.html)


#### CWE Id: [ 352 ](https://cwe.mitre.org/data/definitions/352.html)


#### WASC Id: 9

#### Source ID: 3

### [ Cookie with SameSite Attribute None ](https://www.zaproxy.org/docs/alerts/10054/)



##### Low (Medium)

### Description

A cookie has been set with its SameSite attribute set to "none", which means that the cookie can be sent as a result of a 'cross-site' request. The SameSite attribute is an effective counter measure to cross-site request forgery, cross-site script inclusion, and timing attacks.

* URL: https://ehikebe.azurewebsites.net/
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: ``
* URL: https://ehikebe.azurewebsites.net:443
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: ``


### Solution

Ensure that the SameSite attribute is set to either 'lax' or ideally 'strict' for all cookies.

### Reference


* [ https://tools.ietf.org/html/draft-ietf-httpbis-cookie-same-site ](https://tools.ietf.org/html/draft-ietf-httpbis-cookie-same-site)


#### CWE Id: [ 1275 ](https://cwe.mitre.org/data/definitions/1275.html)


#### WASC Id: 13

#### Source ID: 3

### [ Cookie without SameSite Attribute ](https://www.zaproxy.org/docs/alerts/10054/)



##### Low (Medium)

### Description

A cookie has been set without the SameSite attribute, which means that the cookie can be sent as a result of a 'cross-site' request. The SameSite attribute is an effective counter measure to cross-site request forgery, cross-site script inclusion, and timing attacks.

* URL: https://ehikebe.azurewebsites.net/
  * Method: `GET`
  * Parameter: `ARRAffinity`
  * Attack: ``
  * Evidence: `Set-Cookie: ARRAffinity`
* URL: https://ehikebe.azurewebsites.net:443
  * Method: `GET`
  * Parameter: `ARRAffinity`
  * Attack: ``
  * Evidence: `Set-Cookie: ARRAffinity`


### Solution

Ensure that the SameSite attribute is set to either 'lax' or ideally 'strict' for all cookies.

### Reference


* [ https://tools.ietf.org/html/draft-ietf-httpbis-cookie-same-site ](https://tools.ietf.org/html/draft-ietf-httpbis-cookie-same-site)


#### CWE Id: [ 1275 ](https://cwe.mitre.org/data/definitions/1275.html)


#### WASC Id: 13

#### Source ID: 3

### [ Cross-Domain JavaScript Source File Inclusion ](https://www.zaproxy.org/docs/alerts/10017/)



##### Low (Medium)

### Description

The page includes one or more script files from a third-party domain.

* URL: https://ehikebe.azurewebsites.net/
  * Method: `GET`
  * Parameter: `https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js`
  * Attack: ``
  * Evidence: `<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>`
* URL: https://ehikebe.azurewebsites.net/%3Fname../../../../../../../../../../../../../../../../Windows/system.ini=abc
  * Method: `GET`
  * Parameter: `https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js`
  * Attack: ``
  * Evidence: `<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>`
* URL: https://ehikebe.azurewebsites.net/%3Fname=abc
  * Method: `GET`
  * Parameter: `https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js`
  * Attack: ``
  * Evidence: `<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>`
* URL: https://ehikebe.azurewebsites.net/%3Fnamec:%255CWindows%255Csystem.ini%2500=abc
  * Method: `GET`
  * Parameter: `https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js`
  * Attack: ``
  * Evidence: `<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/js/bootstrap.bundle.min.js"></script>`


### Solution

Ensure JavaScript source files are loaded from only trusted sources, and the sources can't be controlled by end users of the application.

### Reference



#### CWE Id: [ 829 ](https://cwe.mitre.org/data/definitions/829.html)


#### WASC Id: 15

#### Source ID: 3

### [ Incomplete or No Cache-control Header Set ](https://www.zaproxy.org/docs/alerts/10015/)



##### Low (Medium)

### Description

The cache-control header has not been set properly or is missing, allowing the browser and proxies to cache content.

* URL: https://ehikebe.azurewebsites.net/
  * Method: `GET`
  * Parameter: `Cache-Control`
  * Attack: ``
  * Evidence: ``


### Solution

Whenever possible ensure the cache-control HTTP header is set with no-cache, no-store, must-revalidate.

### Reference


* [ https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html#web-content-caching ](https://cheatsheetseries.owasp.org/cheatsheets/Session_Management_Cheat_Sheet.html#web-content-caching)
* [ https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Cache-Control ](https://developer.mozilla.org/en-US/docs/Web/HTTP/Headers/Cache-Control)


#### CWE Id: [ 525 ](https://cwe.mitre.org/data/definitions/525.html)


#### WASC Id: 13

#### Source ID: 3

### [ Server Leaks Information via "X-Powered-By" HTTP Response Header Field(s) ](https://www.zaproxy.org/docs/alerts/10037/)



##### Low (Medium)

### Description

The web/application server is leaking information via one or more "X-Powered-By" HTTP response headers. Access to such information may facilitate attackers identifying other frameworks/components your web application is reliant upon and the vulnerabilities such components may be subject to.

* URL: https://ehikebe.azurewebsites.net/
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `X-Powered-By: ASP.NET`

### Solution

Ensure that your web server, application server, load balancer, etc. is configured to suppress "X-Powered-By" headers.

### Reference


* [ http://blogs.msdn.com/b/varunm/archive/2013/04/23/remove-unwanted-http-response-headers.aspx ](http://blogs.msdn.com/b/varunm/archive/2013/04/23/remove-unwanted-http-response-headers.aspx)
* [ http://www.troyhunt.com/2012/02/shhh-dont-let-your-response-headers.html ](http://www.troyhunt.com/2012/02/shhh-dont-let-your-response-headers.html)


#### CWE Id: [ 200 ](https://cwe.mitre.org/data/definitions/200.html)


#### WASC Id: 13

#### Source ID: 3

### [ Server Leaks Information via 'X-Powered-By' HTTP Response Header Field(s)(script) ](https://www.zaproxy.org/docs/alerts/50001/)


#### CWE Id: [ 200 ](https://cwe.mitre.org/data/definitions/200.html)


#### WASC Id: 13

#### Source ID: 3

### [ Server Leaks Version Information via 'Server' HTTP Response Header Field(script) ](https://www.zaproxy.org/docs/alerts/50001/)



##### Low (Medium)

### Description

The web/application server is leaking version information via the 'Server' HTTP response header. Access to such information may facilitate attackers identifying other vulnerabilities your web/application server is subject to.

* URL: https://ehikebe.azurewebsites.net/
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `[Microsoft-IIS/10.0]`

### Solution

Ensure that your web server, application server, load balancer, etc. is configured to suppress the 'Server' header or provide generic details.

### Reference



#### Source ID: 4

### [ A Client Error response code was returned by the server ](https://www.zaproxy.org/docs/alerts/100000/)


##### Informational (High)

### Description

A response code of 400 was returned by the server.
This may indicate that the application is failing to handle unexpected input correctly.
Raised by the 'Alert on HTTP Response Code Error' script

* URL: https://ehikebe.azurewebsites.net/
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 400`
* URL: https://ehikebe.azurewebsites.net/%3Fnamec:%255CWindows%255Csystem.ini%2500=abc
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 400`
* URL: https://ehikebe.azurewebsites.net/%3Fnamec:%255CWindows%255Csystem.ini=abc
  * Method: `GET`
  * Parameter: ``
  * Attack: ``
  * Evidence: `HTTP/1.1 400`

#### CWE Id: [ 615 ](https://cwe.mitre.org/data/definitions/615.html)


#### WASC Id: 13

#### Source ID: 3

### [ SameSite cookie attribute protection used ](https://www.zaproxy.org/docs/alerts/50001/)



##### Informational (High)

### Description

The current site use the 'SameSite' cookie attribute protection on cookie named 'ARRAffinitySameSite', value is set to 'None' protection level.

* URL: https://ehikebe.azurewebsites.net/
  * Method: `GET`
  * Parameter: `Cookie named: 'ARRAffinitySameSite'`
  * Attack: ``
  * Evidence: `None`
* URL: https://ehikebe.azurewebsites.net:443
  * Method: `GET`
  * Parameter: `Cookie named: 'ARRAffinitySameSite'`
  * Attack: ``
  * Evidence: `None`

### Solution

CSRF possible vulnerabilities presents on the site will be mitigated depending on the browser used by the user (browser defines the support level for this cookie attribute).

### Reference



#### CWE Id: [ 352 ](https://cwe.mitre.org/data/definitions/352.html)


#### WASC Id: 9

#### Source ID: 3
--------------------------------------------------------------------------------------------------------------------------------------------------------
# Nikto tool
Deze tool vond volgende vulnerability.

The Content-Encoding header is set to "deflate" this may mean that the server is vulnerable to the BREACH attack

--------------------------------------------------------------------------------------------------------------------------------------------------------

# SCA testing:
Voor Sca Testing hebben wij gebruik gemaakt van Dependabot hier zijn geen High of Critical Severity CVSS uitgekomen.

na het scannen van de code via CodeQL hebben we wel volgende alerts opgemerkt:

--------------------------------------
Credentials are hard coded in the source code of the application.

Severity: Critical  

CWE-259  CWE-321  CWE-798  

file: EHikeB/Areas/Identity/Pages/Account/Register.cshtml.cs:152

Solution: Nu dit is voorlopig ongebruikte code en kan worden verwijderd, indien dit toch gebruikt zou worden moet dit worden beveiligd.

--------------------------------------
Inefficient regular expression

Severity: High

CWE-1333  CWE-400  CWE-730

file:

EHikeB/wwwroot/lib/jquery-validation/dist/jquery.validate.js:1394 

EHikeB/wwwroot/lib/jquery-validation/dist/additional-methods.js:1092

Solution: Gelijkaardig porbleem word hier ook beschreven => https://securitylab.github.com/advisories/GHSL-2020-294-redos-jquery-validation/

Dit kan worden gebruikt in [D]DOS aanval.


--------------------------------------------------------------------------------------------------------------------------------------------------------


# Netwerk test => ![ION cannon](https://github.com/EHB-TI/web-app-angry-nerds/blob/main/Internal-Docs/Capture.PNG?raw=true)




--------------------------------------------------------------------------------------------------------------------------------------------------------

# Notes:
pagina heeft een dode redirect deze blijft gewoon de homepage weergeven ==> https://ehikebe.azurewebsites.net/#contact_Section
geen security headers
geen pawnd protectie

onderaan https://ehikebe.azurewebsites.net/css/styles.css kan je C# code zien, dit is niet direct een security issue, maar dit hoort hier niet thuis.

; <<>> DiG 9.10.6 <<>> CAA ehikebe.azurewebsites.net
;; global options: +cmd
;; Got answer:
;; ->>HEADER<<- opcode: QUERY, status: NOERROR, id: 62665
;; flags: qr rd ra; QUERY: 1, ANSWER: 2, AUTHORITY: 1, ADDITIONAL: 1

;; OPT PSEUDOSECTION:
; EDNS: version: 0, flags:; udp: 512
;; QUESTION SECTION:
;ehikebe.azurewebsites.net.	IN	CAA

;; ANSWER SECTION:
ehikebe.azurewebsites.net. 30	IN	CNAME	waws-prod-fra-015.sip.azurewebsites.windows.net.
waws-prod-fra-015.sip.azurewebsites.windows.net. 1800 IN CNAME waws-prod-fra-015-8b2a.germanywestcentral.cloudapp.azure.com.

;; AUTHORITY SECTION:
germanywestcentral.cloudapp.azure.com. 300 IN SOA ns1-08.azure-dns.com. azuredns-hostmaster.microsoft.com. 1 3600 300 2419200 300

;; Query time: 67 msec
;; SERVER: 192.168.1.1#53(192.168.1.1)
;; WHEN: Mon Dec 13 08:40:37 CET 2021
;; MSG SIZE  rcvd: 269


--------------------------------------------------------------------------------------------------------------------------------------------------------

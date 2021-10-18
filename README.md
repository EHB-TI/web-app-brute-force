# Goal
Our goal is to create a platform for the school, to let the students and teachers carpool safely. 
It will be a web app where you can post your itinerary and people will be able to join you directly from the web app.
The users will be able to choose the rate per KM.
To protect the platform from external people, the users will have to register with their student cards.
To make a profit we will take a commission on every carpooling session, or maybe have some ads displayed on the website.
Our long-term goal is to make the system available to a wider audience. For example, let the VUB implement our platform for their university.

# Acceptance criteria
The goals we have in mind will be reached as soon as we can establish an encrypted and secure link between the students. The users have to be able to schedule a carpool session within a couple of minutes. To make sure the exchange of information is secure, the users have to sign up using their student ID. The whole process has to be as secure and efficient as possible to ensure a good user experience.
## Requirements for good UX
- The input fields during the registration will be auto-filled with the data retrieved using the student ID.
- The user can reuse an old carpooling session to create a new one with the same itinerary and data.
- The users can use a map to pick a location easily.
## Requirements to start a session
- The creator and the other users that take part in the carpooling session need to complete their registration using their student ID.
- The location and time of both the departure and arrival need to be filled in correctly.
- The creator and the users have to agree to the payment method they both wish to use. The two payment methods are PayPal and cash.

# Threat model

![Threat Model](images/threat_model/Threat_model.png)

## Data Acces and Exposure
- injection : Use Parameterized SQL commands for all data access.
- Practice Least Privilege - Connect to the database using an account with a minimum set of permissions required to do it's job i.e. not the sa account
- We will not store Encrypted password 
- Enforce passwords with a minimum complexity that will survive a dictionary attack i.e. longer passwords that use the full character set (numbers, symbols and letters) to increase the entropy.
- Use a strong encryption routine such as AES-512 where personally identifiable data needs to be restored to it's original format
- Use TLS 1.2 for your entire site
- Ensure headers are not disclosing information about your application

## Broken Access Control
- Reduce the time period a session can be stolen in by reducing session timeout and removing sliding expiration
- Ensure cookie is sent over HTTPS in the production environment. This should be enforced in the config transforms
- Protect LogOn, Registration and password reset methods against brute force attacks by throttling requests and considering using ReCaptcha
- Use authentication or session management privided by .Net

## Cross site Scripting (XSS)
- Prevention : .NET Frameworks includes the AntiXssEncoder library, which has a comprehensive input encoding library
- Enable a Content Security Policy, this will prevent your pages from accessing assets it should not be able to access (e.g. a malicious script)
- validateRequest is a value in the web.config that enables limited XSS protection in ASP.NET and should be left intact as it provides partial prevention of Cross Site Scripting

## Insecure Deserialization
- Validate User Input, Malicious users are able to use objects like cookies to insert malicious information to change user roles.
- We will not accept Serialized Objects from Untrusted Sources and prevent Deserialization of Domain Objects

## Encryption 
- Use the Windows Data Protection API (DPAPI) for secure local storage of sensitive data.
- In .NET (both Framework and Core) the strongest hashing algorithm for general hashing requirements is System.Security.Cryptography.SHA512.
- In the .NET framework the strongest algorithm for password hashing is PBKDF2, implemented as System.Security Cryptography.Rfc2898DeriveBytes.
- Encrypt sensitive parts of the web.config using aspnet_regiis -pe (command line help).

# Deployment
*minimally, this section contains a public URL of the app. A description of how your software is deployed is a bonus. Do you do this manually, or did you manage to automate? Have you taken into account the security of your deployment process?*
# *you may want further sections*
*especially if the use of your application is not self-evident*

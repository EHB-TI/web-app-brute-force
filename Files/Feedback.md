# Feedback

This is a report discussing and testing the following website: **[Eatee](https://www.eateecats.be/)**

**Team:** [Callback Cats](https://github.com/EHB-TI/web-app-callback-cats)

## Introduction

The emphasis of our testing is on safety. Since functionality, risk and security influence each other, and often even determine each other, the business logic is also expected to be tested. Is the application achieving its objectives? Is the app doing this in a safe way? The threat model of the customer can help us with this. After all, a good threat model also contains risks that are specific to the application. Do we agree with our client's risk assessment? Are the main risks being addressed in a proper manner? We will pay special attention to access rights to see if they are properly enforced? To evaluate this we need to be able to sign up with different roles.

Throughout the testing of the website the uptime was not consistent. 

## 1. Evaluation criteria regarding registration and passwords

### **Log in and Registration:**

Users can **not** create an account in order to log in. This is a problem because the website is only available for users that are logged in. Upon visiting the website the user is prompted with a log in screen but since the users is not allowed to create an account it is impossible for a client to use the website. Demo accounts have been provided to make sure we could test the different functionalities of the website. But an outside user can not create his/her own account to access the services.  
Using the demo accounts we can navigate the different views of the website, the website clearly indicates whether the user is logged in or not and provides the functionality to log out if needed.

Since the registration is not functional, the user informations are not available. The user can not view or modify his/her personal information. Passwords can not be created which indicates that the criteria regarding password creation have not been met.

The passwords that have been provided alongside the demo accounts do not meeet the minimum requirements and are of a risky nature. The passwords do not contain any capital letters, punctuation, numbers or a defined length.

It is not possible to fully test the site, since different functionalities are missing it is nearly impossaible to discuss some of the criteria. 

Registration will not be used in the final version of the projects since it will make use of the Ehb portal API. Log in is a proof-of-concept and is used to differentiate the student and admin views. This will eventually be removed, thus making the above feedback insignificant.

### **Uncaught errors:**

> _The log in does not work on the following version of the website: https://www.eateecats.be/, the log in does work on the following modified version: https://eateecats.be/.  
> We think this occurs because the **[first](https://www.eateecats.be/)** version is a subdomain of the **[second](https://eateecats.be/)** version._


### Acceptance criteria

| Passed | Criteria                                                                              | Notes                                | Severity |
| :----: | --------------------------------------------------------------------------------------| ------------------------------------ | :------: |
|   YES  | As as student I can see the menu of today                                             |  --                                  |  ------  |
|   YES  | As as student I can see the allergies, price and availability of a product/meal       |  --                                  |   HIGH   |
|   NO   | As a student I create a sandwich with available products                              | (1), (2), (3)                        | CRITICAL |
|   YES  | As a student I can pay my order in advance                                            | (4)                                  |   LOW    |
|   YES  | As a student I can log in/log out                                                     | (5)                                  |   LOW    |
|   NO   | As a student I can change my password                                                 | User info are not available.         |  MEDIUM  |
|   NO   | As a student I can update my 2-factor authentication                                  | (6)                                  |  MEDIUM  |
|   --   | As a student I receive an email when my order is ready                                |  --                                  |  ------  |
|   YES  | As a student I can see my previous orders                                             |  --                                  |  ------  |
|   YES  | As a school restaurant employee I can see which orders have been placed               |  --                                  |  ------  |
|   NO   | As a school restaurant employee I can check out an order when it is ready             | (7)                                  |   LOW    |
|   NO   | As a school restaurant employee I can create/view/edit/remove menus                   | This option is not available.        |   LOW    |
|   YES  | As a school restaurant employee I can create/view/edit/remove products                | (8)                                  |   LOW    |
|   YES  | As a school restaurant employee I can check the stock                                 |  --                                  |  ------  |

(1) : Creation is successfull only the first time, once i try to make a new sandwich the website periodically doesn't display the correct information.
(2) : Once the sandwich is created, the details about the specif sandwich are not displayed in the cart.
(3) : Removing one item of the cart results in a complete wipe of the current cart/session.
(4) : Checkout is in test mode, clicking the cancel button redirects you to a success message even though the payment did not succeed.
(5) : The log in/log out did not work properly during the tresting of the application.
(6) : The option is displayed in the profile view but is not eqquiped with any logic/code to execute.
(7) : Orders can not be processed through the admin dashboard, the 'Process' button does not execute any code, and leads to an 502 error.
(8) : Once a product is created the admin is not redirected to the stock page, the admin has to manually go back and refresh the page to see the results.

**Other Issues:**
Orders do not alter the stock of a product. This is not actually testable since we can not perform a legitimate order. No code has been found to perform this.


## Evaluation criteria regarding HTTPS

### **Is HTTPS used everywhere?**

All the views use HTTPS to make sure all communication and customer information is protected. Using HTTPS also prevents Man-in-the-Middle attacks. 

### **SSL Labs server test:**

The server test by **[SSL Labs](https://www.ssllabs.com/ssltest/index.html)** results in a A+ mark. Each response contains a Strict-Transport-Security header;

### **HSTS preload list:**

The domain is present in the HSTS preload list. The following site is used to check its status: [HSTS](https://hstspreload.org/)

### **Security headers:**

The domain contains all the needed security headers. The following site is used to check the headers: [Security Headers](https://securityheaders.com/)


## Evaluation criteria regarding protection against typical web vulnerabilities

We used the following site is to check the CSP Security: [CSP Security](https://cspscanner.com/)
- CSP Protection is active
- XSS (Cross-site scripting): Basic CSP Protection
- Formjacking: Weak CSP Protection
- Clickjacking: Medium CSP Protection
**Warnings:**
- 'base-uri': Missing 'base-uri' allows the injection of base tags that set the base URL for all relative URLs. Used in XSS as CSP bypasses on the 'script-src' directive, and in Formjacking attacks - routing forms to an attacker controlled domain. Must be set to 'none' or 'self'.
- upgrade-insecure-requests: Add 'upgrade-insecure-requests' to protect from ManInMiddle attacks. Another (more strict) option is to use 'block-all-mixed-content' to block mixed content resources (rather than updgrade to secure).

- The needed headers are present and are propperly defined.

- All the used cookies have successfully been implemented and are used on a strict manner.


The `X-Frame-Options` header is defined and combined with the `frame-ancestors`. `X-Content-Type-Options: nosniff` is used to prevent MIME sniffing. 
The only warning that has been detected by the site is the following:


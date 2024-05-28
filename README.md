# Active Directory Password Rotator (ADPasswordRotator)

Active Directory Password Rotator (ADPasswordRotator) is a simple and powerful application, designed to help automate the process of rotating account passwords within an unlimited amount of Microsoft Active Directory domains. Tailored for Managed Service Providers (MSPs), this tool is not only powerful but also easy to use, enhancing the security of crucial accounts by regularly updating the account passwords across an unlimited amount of domains, all without manual intervention. 

Ensuring unique and frequent passwords, ADPasswordRotator helps maintain compliance with stringent security policies, significantly reduces the risk of credential exposure, and can ensure that no manual process is needed when a keyholder leaves the business; all accounts are secure with a simple click to reset all accounts with no downtime or preparation.

This solution is particularly beneficial in environments where managing multiple domains is crucial in small teams. It provides a streamlined and secure approach to password management across various clients. It also monitors and logs to know who and when someone accessed an account's credentials. 


## Features

- **Automated Password Rotation:** Automatically rotates passwords for Active Directory accounts based on a configurable schedule.
- **Multi-Domain Support:** Manage and rotate passwords across an unlimited number of Active Directory domains, making it ideal for MSP environments.
- **JWT Authentication:** Secure access to the application using JSON Web Tokens (JWT) for authentication.
- **Role-based Access Control:** Utilize many levels of roles to help tailor access to fit in with your environment and needs.
- **Secure API Endpoints:** Protect sensitive operations with secure API endpoints requiring authentication.
- **REST API Intergations:** Easy to use for seamless third-party intergrations like IT-GLUE. 

## Technologies Used

- **.NET Core:** Backend developed using .NET Core for robust and scalable performance.
- **JWT:** JSON Web Token for secure authentication.
- **Entity Framework Core:** ORM for data access.
- **Swagger:** Integrated for API documentation and testing.
- **CORS:** Configured for secure cross-origin resource sharing.
- **Blazor** Support for server-side rendering with Razor Pages.

## Getting Started

### Prerequisites

- .NET 6 SDK or later
- Microsoft Active Directory Domain(s)

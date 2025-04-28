# Drivers and Vehicle License Department 

![Block diagram](https://github.com/AhmadZaqiq/Drivers-and-Vehicles-License-Department-DVLD/raw/master/Database/Block%20diagram.png)

---

## Warning: This is not the final version of the code. 

---

## Overview
**This DVLD is built using a 3-tier architecture**, designed to manage all processes related to license applications, fee payments, and exam scheduling. It features a secure login system with role-based access control to ensure authorized and efficient system usage. The application enables seamless handling of applicant data, eligibility verification, and real-time tracking of application statuses. Additionally, it manages license categories, conditions, and fee structures to optimize workflow and ensure compliance with regulatory requirements.

---

## Project Demo

Watch the full project explanation on [YouTube](https://www.youtube.com/watch?v=av5LFYQPJ6s).

---

## Features

### System Architecture
- 3-Tier Design: Secure, modular architecture with role-based access control
- Scalable Framework: Ready for future web/mobile platform migration
- Integrated Database: Centralized applicant and license information storage

---

### License Services
#### Application Processing
- New License Issuance (7 different categories)
- Renewal, Replacement & Release Services
- International License Issuance
- Test Scheduling & Re-examination

#### License Categorization
- Motorcycle Licenses (Small/Heavy)
- Personal & Commercial Vehicle Licenses
- Specialized Licenses (Agricultural, Bus, Heavy Vehicle)
- Category-specific age requirements & validity periods

---

### Testing & Verification
#### Multi-Stage Testing Protocol
- Vision Testing
- Theoretical Knowledge Examination
- Practical Driving Assessment
- Result Recording & Certificate Issuance

---

### Administrative Functions
#### User & Person Management
- Account Administration with Permission Control
- Applicant Data Management & Verification
- Duplicate Prevention & Data Validation

#### Application Tracking
- Status Monitoring & Updates
- Request Filtering & Search Functionality
- Document Processing & Verification

---

### Financial Management
#### Structured Fee System
- Service-specific Application Fees
- Category-based License Charges
- Testing & Re-examination Costs
- Fine Processing for Detained Licenses

---

### Compliance & Reporting

#### Regulatory Enforcement
- Age & Eligibility Verification
- License Status & Condition Management
- Historical Records Maintenance
- Application Auditing & Tracking

---

## Technologies Used
- **Microsoft .NET Framework**: Application framework for building Windows desktop apps and services.
- **C#**: Primary object-oriented programming language for developing business logic.
- **Siticone UI**: Library for creating modern, customizable user interfaces.
- **ADO.NET**: Data access technology for interacting with SQL Server.
- **SQL Server**: Relational database management system for storing application data.

---

## DataBase Diagram

![Database Diagram](https://github.com/AhmadZaqiq/Drivers-and-Vehicles-License-Department-DVLD/raw/master/Database/Database%20diagram.png)

---

## How to Run the Project

### Step 1: Clone the Repository
```
git clone https://github.com/AhmadZaqiq/Drivers-and-Vehicles-License-Department-DVLD.git
cd Drivers-and-Vehicles-License-Department-DVLD
```
### Step 2: Open the Project in Visual Studio 2022
Ensure **Visual Studio 2022** is installed on your Computer, then open the project in **Visual Studio 2022**.

### Step 3: Install the Siticone UI Library
In Visual Studio, open the **NuGet Package Manager** and install the **Siticone.NetFramework.UI** library.

### Step 4: Install SQL Server
If you don’t have **SQL Server** installed, download and install it from the official [SQL Server website](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).

### Step 5: Update the Connection String
In the `DVLD Data Access \ clsDataAccessSettings` file, update the `ConnectionString` with your local SQL Server instance details:
```
public static string ConnectionString = "Server=.;Database=DVLD;User id=YOUR_USER;Password=YOUR_PASSWORD";
```

### Step 6: Restore the Database
Before running the project, ensure that the database is restored by executing the following command in **SQL Server Management Studio (SSMS)**:
``` 
Restore Database DVLD from disk='put_location_of_your_bak_file';
``` 


---

## Project explanation

###  Main Services Overview

| # | Service Name                          | Description                         | Application Fee |
|---|---------------------------------------|-------------------------------------|-----------------|
| 1 | New License Issuance Service          | Apply for a new license             | $15             |
| 2 | License Renewal Service               | Renew an existing license           | $5              |
| 4 | Lost License Replacement Service      | Replace a lost license              | $10             |
| 5 | Damaged License Replacement Service   | Replace a damaged license           | $5              |
| 6 | License Release Service (from hold)   | Release Detained Driving Licsense   | $15             |
| 6 | International License Issuance Service| Apply for an international license  | $50             |
| 7 | Retest Service                        | Apply for a new test after failing  | $5              |

To obtain a service, the applicant must submit a request and pay the associated fee.

---

### Application Information:

- **Application Number**
- **Application Date**
- **Person ID (Applicant)**  
   Searched using the national ID; if the person does not exist in the system, the user must add them first.
- **Application Type**  
   Based on the selected service from the table above.
- **Application Status**  
   (New, Cancelled, Completed)
- **Application Fee Paid**

#### Special Case – New License Issuance:
  → The category of the requested license must be specified.
  
  → The system must ensure that the applicant does not already hold a license of the same category.

- The system must also verify that the applicant does not have a previous **incomplete** request of the same type.

Each application is linked to a person in the system, and a person can have multiple requests.

### Applicant Information Storage

Applicant information must be retained in the system, and it should not be duplicated. The applicant's details include:

- **National ID Number**
- **Full Name**
- **Date of Birth**
- **Address**
- **Phone Number**
- **Email Address**
- **Nationality**
- **Personal Photo**

---

## Details of Services Provided:


### License Categories Overview

| # | Category Name                     | Description                                      | Min. Age | Fee  | Validity |
|---|----------------------------------|--------------------------------------------------|----------|------|----------|
| 1 | Small Motorcycle License         | Operate small motorcycles                        | 18       | $15  | 5 years  |
| 2 | Heavy Motorcycle License         | Operate large/powerful motorcycles               | 21       | $30  | 5 years  |
| 3 | Regular Driving License          | Operate personal light vehicles                  | 18       | $20  | 10 years |
| 4 | Commercial Driving License       | Operate taxi or limousine                        | 21       | $200 | 10 years |
| 5 | Agricultural Vehicle License     | Operate tractors/plowing machines                | 21       | $50  | 10 years |
| 6 | Small & Medium Bus License       | Operate small/medium buses                       | 21       | $250 | 10 years |
| 7 | Truck & Heavy Vehicle License    | Operate large buses or trucks                    | 21       | $300 | 10 years |


### 1. New License Issuance Service

The applicant can apply for a specific license category. The details of the driving license categories are as follows:

---

#### 1.1 First Category: Small Motorcycle License (Motorcycle License)
- Allows the driver to operate small motorcycles.
- Suitable for motorcycles with small engine capacity and limited power.
- Minimum age: 18 years.
- License fee: $15 in addition to the application fee.
- License validity: 5 years.

---

#### 1.2 Second Category: Heavy Motorcycle License (Large Motorcycle License)
- Allows the driver to operate large and powerful motorcycles.
- Minimum age: 21 years.
- License fee: $30 in addition to the application fee.
- License validity: 5 years.

---

#### 1.3 Third Category: Regular Driving License (Car License)
- Allows the driver to operate light vehicles and personal cars.
- Minimum age: 18 years.
- License fee: $20 in addition to the application fee.
- License validity: 10 years.

---

#### 1.4 Fourth Category: Commercial Driving License (Taxi/Limousine)
- Allows the driver to operate taxi or limousine vehicles.
- Minimum age: 21 years.
- License fee: $200 in addition to the application fee.
- License validity: 10 years.

---

#### 1.5 Fifth Category: Agricultural Vehicle Driving License (Tractors/Tillage Equipment)
- Allows the driver to drive all agricultural vehicles.
- Minimum age: 21 years.
- License fee: $50 in addition to the application fee.
- License validity: 10 years.

---

#### 1.6 Sixth Category: Small and Medium Bus License
- Allows the driver to drive small and medium buses.
- Minimum age: 21 years.
- License fee: $250 in addition to the application fee.
- License validity: 10 years.

---

#### 1.7 Truck and Heavy Vehicle License
- Allows the driver to drive trucks and heavy vehicles such as buses and large trucks.
- Minimum age: 21 years.
- License fee: $300 in addition to the application fee.
- License validity: 10 years.

---

## License Category Information in the System:

- **License Class ID**
- **Class Name**
- **Class Description**
- **Minimum Allowed Age**: The minimum age required for this license.
- **Validity Length**: The number of years this license will be valid.
- **Class Fees**: The fees for this license class.

---

## Conditions for Applying for a License Based on the Requested Category:

- **Allowed Driving Age**: The applicant must be of the required age for the requested license category. The system should reject the application if this condition is violated.
- **No Previous License of the Same Category**: The applicant must not already hold a license of the same category. The system should reject the application if this condition is violated.
- An applicant can hold multiple licenses from different categories, such as a small vehicle license and a motorcycle license.
- **Personal Documents**: A valid identity document, such as a passport or national ID card, must be provided.
- **Education and Training**: The applicant must submit a certificate of completion of driving courses before being eligible to apply for tests.

---

## Tests to Pass in Sequence:

#### 1. Vision Test
- A test appointment is scheduled, and fees are paid. Medical tests are conducted to verify the applicant's health and visual suitability for driving. The results are recorded in the system, and the date and result (pass or fail) should be retained.
- **Test Fee**: $10.
- If the applicant fails, they are not allowed to proceed or be granted a license. The applicant must correct their vision either with glasses or surgery and schedule another vision test appointment.

---

#### 2. Theoretical Test
- After passing the vision test, an appointment for the theoretical test is scheduled, and the fees are paid (appointment is manually set by the user). The applicant must answer questions related to traffic laws and driving safety.
- The exam is paper-based outside the system, and the result (pass or fail) with the score out of 100 is recorded in the system.
- **Test Fee**: $20.
- If the applicant fails, they must schedule another appointment and pay the test fee again.

---

#### 3. Practical Driving Test
- After passing the previous tests, an appointment for the practical driving test is scheduled, and the fees are paid (appointment is manually set by the staff). The applicant must pass a practical driving test to evaluate their ability to control the vehicle and follow traffic rules.
- **Test Fee**: Determined based on the license category.
- If the applicant fails, they can schedule a new appointment and pay the fees again.

---

 → Each test has a fee that must be paid before taking it and when scheduling an appointment.
 
 → The applicant can retake the test if they fail it by scheduling a new appointment and paying the fee again.
 
 → The test fee is determined by the license category applied for.

---

## Issuing the Driving License:

After passing all tests and meeting the required conditions, the driving license is issued with the following information:

- **License Number**
- **License Holder's Photo**
- **National ID Number of the License Holder**
- **License Holder's Full Name**
- **Date of Birth of the License Holder**
- **License Category**
- **Issue Date**
- **Expiration Date**
- **License Conditions (as notes)**
- **License Status**: New, Replacement for Lost, Replacement for Damaged, Renewal (first-time status is "New").

---

## 🛠️ License Services Overview

---

### 1 License Inquiry Service

- Allows searching for licenses using **National ID** or **License Number**.
- Once a license is issued, the applicant becomes an **official driver** and is assigned a **unique driver number**.
- This driver number is added **once** and all future licenses are **linked** to it.

---

### 2 Re-Examination Service

- Schedule a re-exam by entering the **previous test number**.
- Only available if the **previous test was failed**.
- **Service Fee**: `$5` + applicable **test fee** based on license category.
- Appointments are **manually scheduled**.
- A **new request number** is created and **linked** to the original.
- Only **one appointment** can be made per test type.

---

### 3 Driving License Renewal Service

- Renew an existing driving license.
- **Fee**: `$10` on request submission.
- Must **pass a vision test** after scheduling an appointment.
- The **expired license** must be submitted before renewal.

---

### 4 Replacement for Lost License

- Issue a new license for a **lost one**.
- System checks to ensure the license is **not reserved/frozen**.
- **Fee**: `$20`.
- Applicant must **submit the expired license**, if available.

---

### 5 Replacement for Damaged License

- Issue a new license for a **damaged one**.
- **Damaged license must be submitted**.
- **Fee**: `$20`.
- The system records the **replacement issue date**.

---

### 6 License release Service

- release a detained license after paying the **fine fees**.
- The **release date** is recorded in the system.

---

### 7 International Driving License Issuance Service

- Enables issuing an **international driving license** with a system-defined validity period (*configurable*).
- Only available for holders of a **Category 3 License** (*Standard Car License*) that is **neither expired nor suspended**.
- **Service Fee**: `$20`.
- If an active international license already exists, it **must be canceled** before issuing a new one.
- The system must **retain records of all previously issued international licenses**.

---

## 🛠️ System Management

###  1. User Management

The system must support the following user-related operations:

-  Add user by linking to an existing person in the system.
-  View user information.
-  Edit user information.
-  Delete user.
-  Freeze user account.
-  Assign roles and permissions to users.

---

####  User Information Structure

Each user profile must contain the following:

-  **National ID Number**  
-  **Full Name** (four parts)  
-  **Date of Birth**  
-  **Address**  
-  **Phone Number**  
-  **Email Address**  
-  **Nationality**  
-  **Profile Picture**  
-  **Username**  
-  **Password**

---

---

###  2 Person Management

The system must support full management of persons, including:

-  **Search** for a person by **National ID number**.
-  **View** a person's information.
-  **Add** a new person.
-  **Edit** a person's details.
-  **Delete** a person.
-  Duplicate persons with the same **National ID number** are **not allowed**.

####  Person Information

Each person record must include:

-  **National ID Number**  
-  **Full Name**  
-  **Date of Birth**  
-  **Address**  
-  **Phone Number**  
-  **Email Address**  
-  **Nationality**  
-  **Personal Photo**

---

###  3 Request Type Management

The system must allow managing request types through:

-  Search by **Request Number**.
-  Search by **National ID Number** of the person.
-  **View a list** of requests.
-  **View details** of a specific request (including request fees).
-  **Edit** request information.
-  **Filter** requests by their status.

---

###  4 Test Type Management

- The available **test types** are fixed in the system.
-  The system must allow modification of **test fees only**.

---

### 5 License Category Management

- License categories are **predefined** in the system.
-  The system must allow editing of:
-  **Minimum Age Requirement**
-  **License Validity Duration**
-  **License Fees**

---

### 6 Driving License Reservation

This feature allows the system to **reserve a license**, requiring:

-  **License Number**
-  **Reservation Fine**
-  **Reason** for the reservation
-  **Reservation Date**

---

## Course & Certification  

#### This project was completed as part of Course 19 in the learning roadmap of [Programming Advices](https://programmingadvices.com/). Successfully finishing this course has significantly contributed to the development of my software development and project implementation skills.
---

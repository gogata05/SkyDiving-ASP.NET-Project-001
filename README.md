SkyDiving-ASP.NET-Project-001 

# SkyDiving
SoftUni ASP.NET Advanced April 2024 Project Defence

## Introduction
SkyDiving is application for creating/accepting jumps requests and for buying skydiving equipment.

## Features
- Google Maps with Econt offices in the cart view
- Live Support chat added for support user/admin

### User Roles
- **Jumper**: Upon registration, can Add, Edit, Access All Jumps, View My Jumps, Accept/Decline offers, Search, Use Live support Chat, View their orders, Buy equipment, Rate the instructor with stars
- **Instructor**: Jumper can become instructor from Instructors/Join Our Instructors button, can send offers for jumps
- **Admin**: Seeded, access Admin page, Add/Edit jumps, Add/Edit/Delete equipments, Accept/Decline jumps, Complete Orders, View jumps statistics, Reply to Message Requests Live Support Chat

## Role Details:

### Jumper Role
- Jumpers can Add jumps  
- The jump is sent for admin review and can be accepted or declined.  
- Jumper can Edit jump before it is Accepted from the Admin  
- If the jump is Taken or Accepted it can not be deleted  
- Receive offers  
- Jumper can receive offer for his jump(jumps/My jump Offers - one offer from instructor)  
- Offers can be accepted or declined:  
- If offer is accepted the current jump is marked as "Taken"
- When the jump is completed jumper can mark the jump as "Completed" from jumps/My jumps and rate the instructor.  
- Search equipments  
- Equipments can be added to user's cart where quantity is selected, address is required to submit the order. From the menu button the user can review his order status.  
- Rate the instructor with stars after jump completed

### Instructor Role
- Jumper can become instructor from Instructors/Join Our Instructors button  
- Instructors can send offers for all available jumps in the jumps menu  
- Instructor can Search equipments  
- Equipments can be added to user's cart where quantity is selected, address is required to submit the order. From the menu button the user can review his order status.

### Admin Role
- Can access Administration page:  
- Add/Edit jumps in All Jumps
- Accept/Decline jumps in Admin area 
- Add/Edit/Delete Equipments
- Review Orders and mark them as Completed  
- View jumps statistics
- Reply to Message Requests

## Roles logins:
- Jumper: `username: jumper`, `password: jumper`
- Instructor: `username: instructor`, `password: instructor`
- Admin: `username: admin`, `password: admin`

## How to use?
- 0.Download the repository and extract it to folder
- 1.Open Skydiving.sln with visual studio 2022
- 2.In appsetting.json add your personal "ConnectionStrings"
- 3.right click on Skydiving Project and "Set as Startup Project"
- 4.In "Package Manager Console" with Default project: "Skydiving.Infastructure" type: update database
- 5.Ctrl+F5
- 6.Open Url localhost on your browser: https://localhost:7160/
- 7.Enjoy!


## Used libraries:
    - `SignalR` - for realtime live chat
    - `Pace`, - for page load progress bars
    - `Toastr` - for notifications 
    - `jQuery` - simplifying html and css
    - `bootstrap` - CSS Framework

## Database

SSMS and MS SQL are used for storing & managing the data.

## Tests

- `Unit Tests`

## Demo
Live demo at Replit - 

## Photos


Cart with Google Maps and Econt offices:

![image](https://imgur.com/gLzDE4N.png)



Live Chat Support between customer and admin:


![image](https://imgur.com/Io33tqC.png)



Home page with the last 3 equipments added:

![image](https://imgur.com/ot8FEoE.png) 



Equipment shop:

![image](https://imgur.com/EgTjepA.png) 



Customer can Rate with 1/5 stars The Instructor:

![image](https://imgur.com/RmWADWi.png) 



Add jump request:

![image](https://imgur.com/c3omqXI.png) 



My Created Jumps:

![image](https://imgur.com/WkJTLkT.png) 



Accept or Decline offers:

![image](https://imgur.com/BTGCIoB.png) 



My equpment orders:

![image](https://imgur.com/j6Kmicg.png) 



Register:

![image](https://imgur.com/gTITz1H.png) 



Instructor can send offers:

![image](https://imgur.com/foiHmpJ.png) 



Admin can add equipment:

![image](https://imgur.com/oyQnppZ.png) 



Admin can edit/delete equipment:

![image](https://imgur.com/cOrd3wA.png) 



Admin can View All Orders and Mark as Complete any Order:

![image](https://imgur.com/HbFaz91.png) 





Admin can View Jump Statistics:

![image](https://imgur.com/IIGwVpR.png) 

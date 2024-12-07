# **Team Selection API**

## **Overview**
The Team Selection API allows you to manage players with specific skills and positions and select the best players based on requested parameters. This API supports adding, updating, listing, and deleting players, as well as selecting the best player for a given position and skill.

---

## **Technologies Used**
- **C#**
- **ASP.NET Core**
- **Swagger for API documentation**
- **Dependency Injection for services**

---

## **Setup Instructions**

### **1. Clone the Repository**
Clone the repository to your local machine:
```bash
git clone <repository-url>


### **2. Open in Visual Studio**
- Open the solution file in Visual Studio.

### **3. Build the Project**
- Restore all dependencies by building the project:
  ```bash
  dotnet build
  ```

### **4. Run the Application**
- Start the application:
  ```bash
  dotnet run
  ```

- The application will run locally, typically at [http://localhost:5019](http://localhost:5019).

### **5. Access Swagger UI**
- Open a browser and navigate to:
  [http://localhost:5019/swagger](http://localhost:5019/swagger)
- Use Swagger to test the API endpoints.

---

## **API Endpoints**

### **Base URL**
```http
http://localhost:5019
```

### **1. Add a Player**
**Endpoint:**  
`POST /players/add`

**Request Example:**
```http
POST http://localhost:5019/players/add
Content-Type: application/json

{
  "name": "John Doe",
  "position": "defender",
  "skills": [
    { "name": "defense", "value": 85 },
    { "name": "speed", "value": 70 }
  ]
}
```

**Response:**  
```
200 OK
Player added.
```

---

### **2. Update a Player**
**Endpoint:**  
`PUT /players/update`

**Request Example:**
```http
PUT http://localhost:5019/players/update
Content-Type: application/json

{
  "id": 1,
  "name": "John Updated",
  "position": "midfielder",
  "skills": [
    { "name": "attack", "value": 90 },
    { "name": "stamina", "value": 75 }
  ]
}
```

**Response:**  
```
200 OK
Player updated.
```

---

### **3. Delete a Player**
**Endpoint:**  
`DELETE /players/delete/{id}`

**Request Example:**
```http
DELETE http://localhost:5019/players/delete/1
```

**Response:**  
```
200 OK
Player deleted.
```

---

### **4. List All Players**
**Endpoint:**  
`GET /players/list`

**Request Example:**
```http
GET http://localhost:5019/players/list
Accept: application/json
```

**Response Example:**
```json
[
  {
    "id": 1,
    "name": "John Doe",
    "position": "defender",
    "skills": [
      { "name": "defense", "value": 85 },
      { "name": "speed", "value": 70 }
    ]
  }
]
```

---

### **5. Select the Best Player**
**Endpoint:**  
`POST /players/select`

**Request Example:**
```http
POST http://localhost:5019/players/select
Content-Type: application/json

{
  "position": "defender",
  "desiredSkill": "defense"
}
```

**Response Example:**
```json
{
  "position": "defender",
  "playerName": "John Doe",
  "skillValue": 85
}
```

**Response if no suitable player is found:**
```
404 Not Found
No suitable player found.
```

---

## **Testing with Swagger**
1. Navigate to the Swagger UI at:  
   [http://localhost:5019/swagger](http://localhost:5019/swagger)

2. Test all endpoints directly through the Swagger interface by providing the required parameters.

---

## **Future Enhancements**
- Add database support for persisting players.
- Implement authentication and authorization.
- Add support for team composition (e.g., selecting a team with multiple positions and skills).
- Add unit and integration tests.

---

## **Contact**
For questions or support, feel free to contact the project maintainer.
```

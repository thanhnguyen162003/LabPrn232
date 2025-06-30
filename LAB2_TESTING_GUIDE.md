# Lab2 API Postman Testing Guide

This guide explains how to use the comprehensive Postman collection for testing the Lab2 Product API with OData support.

## 📋 Test Cases Overview

The collection includes all the requested test cases for Lab2:

### 🛠️ CRUD Operations Tests
- **Create_Success** - Create product
- **GetById_Success** - Get product by ID
- **GetListOData_Success** - Get all products (list)
- **Update_Success** - Update product details
- **Delete_Success** - Delete product

### 🔍 OData Query Tests
- **OData Filter** - Filter by product name and price range
- **OData Select** - Select specific fields
- **OData OrderBy** - Sort by price
- **OData Top** - Limit results
- **OData Count** - Get total count

### ❌ Error Handling Tests
- **GetById_NotFound** - 404 error for non-existent product
- **Update_BadRequest** - 400 error for ID mismatch
- **Create_BadRequest** - 400 error for invalid data

## 🚀 Setup Instructions

### 1. Import the Collection
1. Open Postman
2. Click "Import" button
3. Select the `Lab2_API_Tests.postman_collection.json` file
4. The collection will be imported with all test cases

### 2. Set Up Environment Variables
1. Create a new environment in Postman
2. Add the following variables:
   - `lab2BaseUrl`: `http://localhost:5154` (Lab2 API base URL)
   - `createdProductId`: (will be automatically set after creating a product)

### 3. Prepare Test Data
Before running the tests, ensure you have:

#### Database Setup
- Database `Lab2` is created and running
- At least one category exists in the database (CategoryId = 1)
- Sample data is initialized (DatabaseInit.Initialize runs automatically)

#### Sample Category Data
```sql
-- Ensure you have at least one category
INSERT INTO Categories (CategoryName) VALUES ('Electronics');
```

## 🧪 Running the Tests

### Recommended Test Order
1. **CRUD Operations Tests** (run in sequence)
   - Create_Success
   - GetById_Success
   - GetListOData_Success
   - Update_Success
   - Delete_Success

2. **OData Query Tests** (can run independently)
   - OData Filter - By Product Name
   - OData Filter - By Price Range
   - OData Select - Specific Fields
   - OData OrderBy - Sort by Price
   - OData Top - Limit Results
   - OData Count - Get Total Count

3. **Error Handling Tests** (can run independently)
   - GetById_NotFound
   - Update_BadRequest - ID Mismatch
   - Create_BadRequest - Invalid Data

### Running Individual Tests
- Right-click on any test and select "Run"
- Or click the "Run" button next to each test

### Running Test Collections
- Right-click on a folder (e.g., "CRUD Operations Tests") and select "Run"
- This will run all tests in that folder in sequence

### Running All Tests
- Right-click on the main collection and select "Run"
- This will run all tests in the recommended order

## 📊 Expected Results

### CRUD Operations Tests
| Test Case | Expected Status | Expected Response |
|-----------|----------------|-------------------|
| Create_Success | 201 | Created product object with ID |
| GetById_Success | 200 | Product object with all properties |
| GetListOData_Success | 200 | Array of product objects |
| Update_Success | 204 | No content (successful update) |
| Delete_Success | 204 | No content (successful deletion) |

### OData Query Tests
| Test Case | Expected Status | Expected Response |
|-----------|----------------|-------------------|
| OData Filter | 200 | Filtered array of products |
| OData Select | 200 | Products with only selected fields |
| OData OrderBy | 200 | Sorted array of products |
| OData Top | 200 | Limited array (max 5 items) |
| OData Count | 200 | Array with @odata.count property |

### Error Handling Tests
| Test Case | Expected Status | Notes |
|-----------|----------------|-------|
| GetById_NotFound | 404 | Product not found |
| Update_BadRequest | 400 | ID mismatch in request |
| Create_BadRequest | 400 | Invalid data validation |

## 🔧 Troubleshooting

### Common Issues

1. **Connection Refused**
   - Ensure your Lab2 API is running on `http://localhost:5154`
   - Check if the port is correct in your `launchSettings.json`

2. **404 Not Found**
   - Verify the API endpoints are correct
   - Check if the product ID exists in the database
   - Ensure OData routes are properly configured

3. **500 Internal Server Error**
   - Check the API logs for detailed error messages
   - Verify database connection string
   - Ensure all required dependencies are installed

4. **OData Query Errors**
   - Verify OData is properly configured in Program.cs
   - Check if the query syntax is correct
   - Ensure the entity properties exist

### Database Connection
Make sure your connection string in `appsettings.json` is correct:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(local);Database=Lab2;User ID=sa;Password=1234567890;TrustServerCertificate=True;"
  }
}
```

## 📝 Test Data Requirements

### Product Create Request Format
```json
{
  "productName": "Test Product 001",
  "categoryId": 1,
  "unitPrice": 29.99,
  "unitInStock": 100
}
```

### Product Update Request Format
```json
{
  "productId": 1,
  "productName": "Updated Test Product 001",
  "categoryId": 1,
  "unitPrice": 39.99,
  "unitInStock": 150
}
```

### OData Query Examples
- **Filter**: `?$filter=productName eq 'Test Product'`
- **Select**: `?$select=productId,productName`
- **OrderBy**: `?$orderby=unitPrice desc`
- **Top**: `?$top=5`
- **Count**: `?$count=true`
- **Combined**: `?$filter=unitPrice gt 20&$orderby=unitPrice desc&$top=10`

## 🎯 Success Criteria

All tests should pass with the expected status codes and response formats. The collection includes comprehensive assertions to validate:

- HTTP status codes
- Response structure
- Data types
- OData query functionality
- Error handling
- CRUD operations

## 🔍 OData Features Tested

The Lab2 API supports the following OData features:
- **$filter** - Filtering data
- **$select** - Selecting specific fields
- **$orderby** - Sorting data
- **$top** - Limiting results
- **$count** - Getting total count
- **$expand** - Expanding related entities

## 📞 Support

If you encounter issues:
1. Check the troubleshooting section above
2. Verify your Lab2 API is running correctly
3. Ensure all test data is properly set up
4. Check the API logs for detailed error messages
5. Verify OData configuration in Program.cs

## 🏗️ Project Architecture

Lab2 follows a clean architecture pattern:
- **API Layer**: OData-enabled controllers
- **Service Layer**: Business logic (ProductService)
- **Repository Layer**: Data access (Generic Repository pattern)
- **Entity Layer**: Domain models (Product, Category)

The API uses OData for advanced querying capabilities, making it easy to filter, sort, and paginate data through standard OData query parameters. 
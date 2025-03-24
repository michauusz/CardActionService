# CardAction
CardAction is a service application developed for a recruitment task, managing allowed actions for various card types (Prepaid, Debit, Credit) based on the card status and PIN setting.

# Features:
Configured with Swagger for API documentation.<br />
Handles dynamic adjustments of allowed actions based on the status of the card and whether the PIN is set.<br />
Supports different card types (Prepaid, Debit, Credit) with various states (Ordered, Inactive, Active, Restricted, Blocked, Expired, Closed).<br />

# Setup:
1. Clone this repository.
2. Install dependencies using dotnet restore.
3. Run the application with dotnet run.
4. Access Swagger UI at http://localhost:{port}/swagger for API documentation.

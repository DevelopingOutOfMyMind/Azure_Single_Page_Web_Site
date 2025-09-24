# Copilot Instructions for Azure_Single_Page_Web_Site

This document provides instructions and best practices for GitHub Copilot to follow when assisting with this C# and Blazor single-page web application.

## General C# Best Practices

1.  **SOLID Principles**: Adhere to the SOLID principles of object-oriented design.
    *   **S**ingle Responsibility Principle: A class should have only one reason to change.
    *   **O**pen/Closed Principle: Software entities should be open for extension but closed for modification.
    *   **L**iskov Substitution Principle: Subtypes must be substitutable for their base types.
    *   **I**nterface Segregation Principle: No client should be forced to depend on methods it does not use.
    *   **D**ependency Inversion Principle: Depend on abstractions, not on concretions.

2.  **Naming Conventions**: Use clear, descriptive, and consistent names for variables, methods, classes, and files, following Microsoft's C# naming conventions.

3.  **Asynchronous Programming**: Use `async` and `await` for I/O-bound and other long-running operations to keep the UI responsive and improve scalability. Avoid `async void` except for event handlers.

4.  **LINQ**: Use LINQ for querying and manipulating collections where it enhances readability. For performance-critical code paths, consider traditional loops.

5.  **Exception Handling**: Implement robust error handling using `try-catch-finally` blocks. Log exceptions for debugging purposes and provide user-friendly error messages.

6.  **Dependency Injection (DI)**: Use the built-in DI container to manage dependencies. Register services with appropriate lifetimes (Singleton, Scoped, Transient).

## Blazor Single Page App Best Practices

### Component Design
1.  **Small & Focused Components**: Keep components small and focused on a single responsibility. Decompose large components into smaller, more manageable ones.
2.  **Data Flow**: Use `[Parameter]` attributes to pass data down from parent to child components. Use `EventCallback` to notify parent components of events or changes from child components.
3.  **Code-Behind Files**: For components with significant logic, separate the C# code into a code-behind file (`.razor.cs`) to improve readability and maintainability.

### State Management
1.  **Component State**: For state that is local to a component, use private fields.
2.  **Shared State**: For state shared between components, use a cascaded parameter or a singleton or scoped service registered with the DI container.

### Performance
1.  **Efficient Rendering**: Use the `@key` directive when rendering a list of elements to help Blazor's diffing algorithm efficiently update the DOM.
2.  **Prevent Unnecessary Renders**: Override `ShouldRender()` and return `false` when a component's UI does not need to be updated.
3.  **Virtualization**: Use the built-in `<Virtualize>` component to display large lists of data efficiently.
4.  **JavaScript Interop**: Minimize calls to JavaScript. When necessary, batch calls to reduce the overhead of interop.
5.  **Lazy Loading (Blazor WebAssembly)**: For Blazor Wasm, use lazy loading for assemblies to reduce the initial application download size and improve startup time.

### Data Fetching
1.  **Lifecycle Events**: Fetch data in the `OnInitializedAsync` lifecycle method.
2.  **Loading Indicators**: Always provide visual feedback (e.g., a spinner) to the user while data is being fetched.
3.  **Error Handling**: Wrap data access calls in `try-catch` blocks to handle potential network or API errors gracefully.

### Security
1.  **Authentication & Authorization**: Use the built-in Blazor authentication and authorization mechanisms to secure the application. Use the `<AuthorizeView>` component to show or hide UI elements based on the user's authentication state and roles.
2.  **Input Validation**: Never trust user input. Always validate and sanitize data on the server side, even if client-side validation is also performed.

## Azure Function Deployment Architectural Standards

The following standards are mandatory for all Azure Function App deployments to ensure compliance with security and regulatory requirements.

1.  **Network Isolation**: All Function Apps must be deployed with network integration into a designated corporate Virtual Network (VNet). Public network access to the Function App must be explicitly disabled. Inbound traffic must be secured using a Private Endpoint, and outbound traffic must be routed through the VNet.

2.  **Identity-Based Access**: Function Apps must use a Managed Identity (System-Assigned or User-Assigned) for all communication with other Azure resources (e.g., Azure Storage, Key Vault, Databases). The use of connection strings or access keys in application settings for authenticating to other Azure services is prohibited. Access control must be enforced using Azure Role-Based Access Control (RBAC) following the principle of least privilege.

3.  **Secure Secrets Management**: All application secrets, keys, and connection strings must be stored in Azure Key Vault. The Function App must be configured to retrieve these secrets from Key Vault using its Managed Identity. The Key Vault itself must be secured with a Private Endpoint and firewall rules, restricting access to the approved VNet.

4.  **Comprehensive Auditing and Monitoring**: All Function Apps must have diagnostic settings configured to export all logs and metrics to the central Log Analytics workspace for retention and analysis. Application Insights must be enabled for performance monitoring and distributed tracing. This ensures a complete audit trail for all executions and interactions, as required for regulatory reporting.

5.  **Infrastructure as Code (IaC) Deployment**: All Azure Functions and their related infrastructure (App Service Plan, Storage, Key Vault, etc.) must be defined and deployed using approved Infrastructure as Code (IaC) templates, such as ARM or Bicep. Manual deployments via the Azure Portal are forbidden for production environments to ensure consistency, repeatability, and auditable changes.
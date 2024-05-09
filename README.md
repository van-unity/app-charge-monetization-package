# AppCharge Monetization System

## Overview

The AppCharge Monetization System is designed to provide a robust solution for managing and processing in-game purchases outside of traditional app stores, thereby reducing fees and increasing revenue for game developers.

## System Design

The AppCharge system consists of several key components working together to manage product information and process payments:

- **AppChargeManager**: Acts as the central manager for the application, ensuring that all parts of the monetization system are correctly initialized and managed throughout the application's lifecycle.
- **MonetizationSettings**: A ScriptableObject that stores and manages configurations for different products available for purchase. It serves as a central repository for product data.
- **StoreManager**: Handles the logic for initiating purchases and processing the results, whether successful or failed.
- **PaymentProcessor**: An interface implemented by any class that handles payment transactions, allowing for flexibility in payment methods and providers.
- **TestPaymentProcessor**: A concrete implementation of the PaymentProcessor, simulating payment transactions for testing purposes.

## Application Design

The application is designed with a singleton pattern for the `AppChargeManager`, ensuring it remains active and unique across the game's runtime. This manager initializes and holds references to `MonetizationSettings` and `StoreManager`, orchestrating the flow of data and actions across the system.

### Platform Handling

The system includes utilities to manage and detect the current platform, adjusting the available products and services accordingly. Platform-specific behavior is encapsulated within `PlatformUtils`, providing a clear and maintainable method for platform differentiation.

## Internal Code Design

### Singleton Implementation

The `AppChargeManager` and its persistent nature are implemented through the `MonoBehaviourSingletonPersistent<T>` class. This pattern ensures that initialization and destruction sequences are managed consistently, avoiding common pitfalls such as multiple instances or state inconsistencies after scene transitions.

### Asynchronous Payment Processing

Payment processing is handled asynchronously, allowing the game to remain responsive during network requests or other I/O operations. The `IPaymentProcessor` interface and its implementations use C#'s `Task`-based asynchronous pattern to perform operations without blocking the main game thread.

### Error Handling

Error handling is implemented across all layers of the application, with specific exceptions for different error types (e.g., `ProductNotFoundException`, `PlatformNotSupportedException`). 

### Event-Driven Communication

The `StoreManager` uses events to communicate purchase results back to other parts of the system, such as UI components or analytics trackers. This loose coupling allows different parts of the game to react to purchase outcomes without direct dependencies on the store's internal logic.



# LitePrimitives

![NuGet](https://img.shields.io/nuget/v/LitePrimitives)
![NuGet](https://img.shields.io/nuget/dt/LitePrimitives)

A small list of primitive types to help with modern .NET development.

## What LitePrimitives supports
**LitePrimitives** supports the following primitive types:

 - `Unit`: A value type that represents *no value* (the functional programming equivalent of `void`).
   - Unlike the `void` type, `Unit` is a returnable type, which helps promote method chaining.
 - `IError`: An interface which all error types in this library inherit from.
   - `Failure`: The standard error type, suitable for when an operation turns erroneous.
   - `Fault`: Used for when exceptional errors occur, with the capability of capturing `Exception` types.
   - `Validation`: Designed specifically for validation. Supports a wide range of fields to help facilitate validation workflows.

**LitePrimitives** supports the following **primitive generic types**:
 - `Option<TValue>`: A primitive generic type used to represent optional values, which encapsulates the concept that a value might be present (`Some`) or absent (`None`). This provides a safer alternative for handling null values.
 - `Result<TResponse>`: A primitive generic type used to represent the outcome of an operation, encapsulating either a successful result (`Success`) with a value of type `TResponse`, or a range of errors (`Failure`) of type `IError`, facilitating robust error handling.
 - `Either<TLeft, TRight>`: A primitive generic type used to represent values with two possible types, encapsulating a value that is either of type `TLeft` (`Left`) or `TRight` (`Right`). Useful for scenarios where an operation can return one of two distinct types.


## Design Decisions

### No Properties that inspect the state of a primitive generic type

In other libraries which supports concepts similar to the **primitive generic types** (i.e. `Option`, `Result` and `Either`) will usually have a property defining the current state of the type (e.g. `Result.IsSuccess`).

These types of properties which give insight into the state of the type are not included by design, as *I* feel this restriction forces the user to think properly about the type of operation they need to perform, and also can lead to more robust code.

**LitePrimitives** support a handful selection of extension methods on top of `Match` and `MatchAsync` (which is present in all **primitive generic types**) to ensure that you can properly perform tasks with these types.

### No Implicit construction of generic types

There are currently no implicit conversions of a type to a **primitive generic type**, for example:

```csharp
Option<int> value = 1;
```

The reasoning behind this is due to `Result` cannot implicitly convert `IError`, `IError[]`, or `List<IError>`. If wanted, an implicit conversion can happen on the **ErrorTypes** that are natively defined in **LitePrimitives**, but can't be done nicely with the array or list versions.

For this reason, *I* decided to keep things consistent for everything.

## Installation

Run the following `dotnet` CLI command in your project directory to install **LitePrimitives**:

```
dotnet add package LitePrimitives
```

## How To Use

Once the project has been installed, add the following using statement to the top of your class file:

```csharp
using LitePrimitives;
```

### Option\<TValue>

The recommended approach for instantiating an `Option` is either through `ToOption` extension method (covered later), or via the `Some` or `None` static factory methods:

```csharp
List<string> data = ["One", "Two", "Three"];
int? foundIndex = data.IndexOf("Four");

Option<int> indexOfRow = foundIndex >= 0 // Can't be null or -1
    ? Option<int>.Some(foundIndex.Value)
    : Option<int>.None();
```
To be able to get the value back from this type, you can use either the `Match` or `MatchAsync` methods:

```csharp
string content = indexOfRow.Match(
    some: index => data[index],
    none: () => "Content Not Found"); // This is what gets returned from the above setup
```
The `Option` type supports the following extension methods natively:

#### Bind
If you're finding yourself in a situation where there's code with a series of method calls which depend on the next
but can return `null` for each of them:

```csharp
async Task<ProfilePicture?> GetProfilePictureAsync(int userId)
{
    User? user = await GetUserByIdAsync(userId);
    
    if (user is null)
    {
        return null;
    }
    
    AccountDetails? accountDetails = await GetAccountDetailsAsync(user);
    
    if (accountDetails is null)
    {
        return null;
    }
    
    ProfilePicture? profilePicture = await DownloadProfilePictureAsync(accountDetails);
    
    return profilePicture;
}
```
Then `Bind/BindAsync` is a suitable alternative, which allows method chaining of operations, and will only continue to the next
operation if the inputted `Option` is in the `Some` state.

```csharp
Option<ProfilePicture> profilePicture = await GetUserByIdAsync(userId) // GetUserByIdAsync Returns Option<User>
    .BindAsync(async user => await GetAccountDetailsAsync(user)) // GetAccountDetailsAsync Returns Option<AccountDetails>
    .BindAsync(async accountDetails => await DownloadProfilePictureAsync(accountDetails)); // DownloadProfilePictureAsync Returns Option<ProfilePicture>
```

#### Map
Suppose you have a singular or series of operations where the output of one is transformed by the next, but you want to avoid dealing with `null` values and maintain the optionality throughout the process:

```csharp
string? CapitalizeUserName(User? user)
{
    if (user is null)
    {
        return null;
    }
    
    // Assume GetNameFromUser doesn't return null
    string name = GetNameFromUser(user);
    string capitalized = name.ToUpper();
    
    return capitalized;
} 
```

In this case, `Map/MapAsync` can be employed to streamline the transformation process by applying a function to the value inside an `Option` if it is in the `Some` state, 
and bypassing the transformation if it is in the `None` state, all the while preserving the optionality:

```csharp
Option<string> capitalizedUserName = GetUserFromThreadPrincipal() // Returns Option<User>
    .Map(user => GetNameFromUser(user)) // Transforms Option<User> to Option<string> by getting the name
    .Map(name => name.ToUpper()); // Transforms the name to uppercase if not None
```

#### OnSome and OnNone

There are instances where we want to perform an action depending on the current state of `Option`. This can be achieved through the
`OnSome/OnSomeAsync` and `OnNone/OnNoneAsync` extension methods:

```csharp
Option<User> currentUser = GetUserFromThreadPrincipal() // Returns Option<User>
            .OnSome(user => LogCurrentUser(user)) // Option<User> value from GetUserFromThreadPrincipal isn't replaced
            .OnNone(() => LogAnonymousUser()); // Option<User> value from GetUserFromThreadPrincipal isn't replaced
```
#### ToOption

As mentioned previously, to construct an `Option<TValue>`, one option is to use the `Some` or `None` static factory methods on `Option` itself. 
This approach falls short in verbosity, which is where the `ToOption` extension method comes in:

```csharp
Option<int> someNumber = 1.ToOption(); // Returns Option<int> in the Some state with 1 as the value
Option<string> noneText = ((string?)null).ToOption(); // Returns Option<string> in the None state
```

#### ToTask

A simple wrapper around `Option`, which calls `Task.FromResult` under the hood:

```csharp
Task<Option<int>> someNumber = 1.ToOption().ToTask();
```
### Result\<TResponse>

The recommended approach for instantiating a `Result` is either through the `ToResult` extension method (covered later), or via the `Success` or `Failure` static factory methods:

```csharp
List<IError> errors = ...; // Fill out errors
int number = 1;

Result<int> numberResult = errors.Count == 0
    ? Result<int>.Success(number)
    : Result<int>.Failure(errors);
```

To be able to get the response back from this type, you can use either the `Match` or `MatchAsync` methods:

```csharp
string numberAsText = numberResult.Match(
    success: num => ParseToNumberInWriting(num), // Function returns a string
    failure: errors => ParseErrors(errors)); // Function returns a string
```

The `Result` type supports the following extension methods natively:

#### Bind

If you're finding yourself in a situation where there's code with a series of method calls which depend on the next but can return `IError` for each of them:

```csharp
async Task<PaymentResult> ProcessPaymentAsync(int orderId)
{
    Order? order = await GetOrderAsync(orderId);
    
    if (order is null)
    {
        return PaymentResult.Failed("Failed to retrieve order");
    }
            
    if (!await ValidateOrderAsync(order))
    {
        return PaymentResult.Failed("Failed to validate order");
    }
    
    decimal total = await CalculateOrderTotalAsync(order);
    
    if (total < 0)
    {
        return PaymentResult.Failed("Order total is negative");
    }
    
    return await ProcessPaymentAsync(order, total);
}
```

Then `Bind/BindAsync` is a suitable alternative, which allows method chaining of operations, 
and will only continue to the next operation if the inputted `Result` is in the `Success` state.

```csharp
Result<PaymentResult> paymentResult = await GetOrderAsync(orderId) // GetOrderAsync Returns Result<Order>
    .BindAsync(async order => await ValidateOrderAsync(order)) // ValidateOrderAsync Returns Result<Order>
    .BindAsync(async order => await CalculateOrderTotalAsync(order)) // CalculateOrderTotalAsync Returns Result<(Order order, decimal total)>
    .BindAsync(async (order, total) => await ProcessPaymentAsync(order, total)); // ProcessPaymentAsync Returns Result<PaymentResult>
```

#### Map

Suppose you have a singular or series of operations where the output of one is transformed by the next, but you want to avoid dealing with errors and maintain the result throughout the process:

```csharp
async Task<(IError[] errors, ArchiveOrder? archiveOrder)> MapToArchiveOrder(int quoteId)
{
    (IError[] quoteErrors, Quote quote) = await GetQuoteAsync(quoteId);
    
    if (quoteErrors.Length > 0)
    {
        return (quoteErrors, null);
    }
    
    Order order = await MapToOrderFromQuote(quote);
    
    return await MapToArchiveOrderFromOrder(order);
}
```

In this case, `Map/MapAsync` can be employed to streamline the transformation process by applying a function to the value inside a `Result` if it's in the `Success` state,
and bypassing the transformation if it is in the `Failure` state, all the while preserving the result:

```csharp
Result<ArchiveOrder> archiveOrderResult = await GetQuoteAsync(quoteId) // Returns Result<Quote>
    .MapAsync(async quote => await MapToOrderFromQuote(quote)) // MapToOrderFromQuote Returns Order
    .MapAsync(async order => await MapToArchiveOrderFromOrder(order)); // MapToArchiveOrderFromOrder Returns ArchiveOrder
```
#### OnSuccess and OnFailure

There are instances where we want to perform an action depending on the current state of `Result`. This can be achieved through the
`OnSuccess/OnSuccessAsync` and `OnFailure/OnFailureAsync` extension methods:

```csharp
Result<Order> currentOrder = GetOrder(orderId) // Returns Result<Order>
    .OnSuccess(order => NotifyWarehouse(order)) // Result<Order> value from GetOrder isn't replaced
    .OnFailure(errors => LogErrors(errors)); // Result<Order> value from GetOrder isn't replaced
```
#### ToResult

As mentioned previously, to construct a `Result<TResponse>`, one option is to use the `Success` or `Failure` static factory methods on `Result` itself.
This approach falls short in verbosity, which is where the `ToResult` extension method comes in:

```csharp
Result<int> successNumber = 1.ToResult(); // Returns Result<int> in the Success state with 1 as the response
Result<int> failureNumber = new Failure("Title", "Description", "Code").ToResult<int>(); // Returns Result<int>in the Failure state with the error
```

#### ToTask

A simple wrapper around `Result`, which calls `Task.FromResult` under the hood:

```csharp
Task<Result<int>> successNumber = 1.ToResult().ToTask();
```

### Either\<TLeft, TRight>

The recommended approach for instantiating an `Either` is either through the `ToEitherLeft/ToEitherRight` extension method (covered later), or via the `Left` or `Right` static factory methods:

```csharp
Car car = new Car();
Bicycle bicycle = new Bicycle();

Either<Car, Bicycle> longDistance = Either<Car, Bicycle>.Left(car);
Either<Car, Bicycle> shortDistance = Either<Car, Bicycle>.Right(bicycle);
```

To be able to get the response back from this type, you can use either the `Match` or `MatchAsync` methods:

```csharp
int numberOfWheels = longDistance.Match(
    left: l => l.NumberOfWheelsPlusSpare(), // Function returns an int
    right: r => r.NumberOfWheels()); // Function returns an int
```

The `Either` type supports the following extension methods natively:

#### BindLeft and BindRight

If you're finding yourself in a situation where there's code with a series of method calls which depend on the next but can return one of two possible states:

```csharp
async Task<BuildCarResult> BuildCarAsync(int jobId)
{
    Job? job = await GetJobAsync(jobId);
    
    if (job is null)
    {
        return BuildCarResult.BeforeProceeding("Need to create a job for this");
    }

    if (!await CheckMaterialsAsync(job))
    {
        return BuildCarResult.BeforeProceeding("Need to purchase the materials needed");
    }
    
    ProductionLineResult productionLineResult = await PrepareProductionLineAsync(job);
    
    if (productionLineResult.TotalManHoursNeeded > 10M)
    {
        return BuildCarResult.BeforeProceeding("Need to assign more labour to the job");
    }
    
    return await BuildCarAsync(productionLineResult);
}
```

Then `BindLeft/BindLeftAsync` and `BindRight/BindRightAsync` are suitable alternatives, which allows method chaining of operations,
and will only continue to the next operation if the inputted `Either` is in the `Left` state (if using `BindLeft/BindLeftAsync`) or `Right` state (if using `BindRight/BindRightAsync`).

```csharp
Either<Car, string> buildCarLeftResult = await GetJobAsync(jobId) // Returns Either<Job, string>
    .BindLeftAsync(async job => await CheckMaterialsAsync(job)) // Returns Either<Job, string>
    .BindLeftAsync(async job => await PrepareProductionLineAsync(order)) // Returns Either<ProductionLineResult, string>
    .BindLeftAsync(async productionLine => await BuildCarAsync(productionLine)); // Returns Either<Car, string>

Either<string, Car> buildCarRightResult = await GetJobAsync(jobId) // GetJobAsync Returns Either<string, Job>
    .BindRightAsync(async job => await CheckMaterialsAsync(job)) // CheckMaterialsAsync Returns Either<string, Job>
    .BindRightAsync(async job => await PrepareProductionLineAsync(order)) // PrepareProductionLineAsync Returns Either<string, ProductionLineResult>
    .BindRightAsync(async productionLine => await BuildCarAsync(productionLine)); // BuildCarAsync Returns Either<string, Car>
```

#### MapLeft and MapRight

Suppose you have a singular or series of operations where the output of one is transformed by the next, but you want to avoid dealing with the other state whilst keeping that modularity:

```csharp
VehicleResult MapVehicleToCar(Vehicle vehicle)
{
    if (vehicle.NumberOfWheels == 2)
    {
        return VehicleResult.IsBike();
    }
    
    VehicleResult vehicleResult = new VehicleResult();    
    vehicleResult.SetCarInfo(vehicle);
    
    return vehicleResult;
}
```

In this case, `MapLeft/MapLeftAsync` and `MapRight/MapRightAsync` can be employed to streamline the transformation process by applying a function to the value inside an `Either`
if it's in the `Left` state (if using `MapLeft/MapLeftAsync`) or `Right` state (if using `MapRight/MapRightAsync`),
and bypassing the transformation if it is in the `Left` or `Right` state (depending on which Map method is used), all the while preserving the result:

```csharp
Either<Car, Bike> leftVehicle = vehicle // Returns Either<Vehicle, Bike>
    .BindLeft(v => CheckNumberOfWheels(v)) // CheckNumberOfWheels Returns Either<Car, Bike>
    .MapLeft(car => MapVehicleToCar(car)); // MapVehicleToCar Returns Car

Either<Bike, Car> rightVehicle = vehicle // Returns Either<Bike, Vehicle>
    .BindRight(v => CheckNumberOfWheels(v)) // CheckNumberOfWheels Returns Either<Bike, Car>
    .MapRight(car => MapVehicleToCar(car)); // MapVehicleToCar Returns Car
```
#### OnLeft and OnRight

There are instances where we want to perform an action depending on the current state of `Either`. This can be achieved through the
`OnLeft/OnLeftAsync` and `OnRight/OnRightAsync` extension methods:

```csharp
Either<PetrolCar, ElectricCar> car = GetCar() // Returns Either<PetrolCar, ElectricCar>
    .OnLeft(c => FillCarWithFuel(c)) // Either<PetrolCar, ElectricCar> from GetCar isn't replaced
    .OnRight(c => ChargeCarAtPoint(c)); // Either<PetrolCar, ElectricCar> from GetCar isn't replaced
```
#### ToEitherLeft and ToEitherRight

As mentioned previously, to construct an `Either<TLeft, TRight>`, one option is to use the `Left` or `Right` static factory methods on `Either` itself.
This approach falls short in verbosity, which is where the `ToEitherLeft` and `ToEitherRight` extension methods comes in:

```csharp
Either<bool, int> leftBool = true.ToEitherLeft<bool, int>();
Either<bool, int> rightInt = 1.ToEitherRight<bool, int>();
```

#### ToTask

A simple wrapper around `Either`, which calls `Task.FromResult` under the hood:

```csharp
Task<Either<bool, int>> rightNumber = 1.ToEitherRight<bool, int>().ToTask();
```

### Unit

The `Unit` type can be instantiated via a parameterless constructor, or via the `Unit.Default` static factory method:

```csharp
Unit first = new Unit();
Unit second = Unit.Default;
```

`Unit` will always return `true` if compared against another `Unit`, and will otherwise return `false`:

```csharp
first == second; // Returns true
first != second; // Returns false
first.Equals(null); // Returns false
first.GetHashCode(); // Returns 0
first.CompareTo(second); // Returns 0
```

## Contribution

I welcome anyone to submit a Github issue if they've noticed a bug, requesting a feature request, or notice inconsistencies in the documentation.

Pull request are welcome, but I would prefer if they're linked to a Github issue, with the commits in the same style as the main branch.
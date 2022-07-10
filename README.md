## Give a Star! :star:

If you like or are using this project please give it a star. Thanks!

# Install

Current version of nuget package - https://www.nuget.org/packages/Antanidoss.Specification/1.0.0

The framework is provided as a set of NuGet packages.

To install the minimum requirements:

```
Install-Package Antanidoss.Specification
```

## Usage

This project is needed to facilitate the use of specifications on large projects.
For example, there is the following class


```csharp
public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
}
```


And for this class, we want to have a repository in which we want to filter this class for certain scenarios


```csharp
public interface IPersonRepository
{
    IEnumerable<Person> GetByName(string name);
    IEnumerable<Person> GetByAge(int age);
    IEnumerable<Person> GetByAgeAndName(int age, string name);
}
```

In this case, we see that this class is difficult to expand and the more properties the Person class has, the more filtering methods there will be.
What solution do I propose? I propose to implement filters as a specification pattern, and connect and combine them as we need.
Let's make the following filter specifications

```csharp
public class PersonByNameSpec : ISpecification<Person>
{
    private readonly string _name;

    public PersonByNameSpec(string name)
    {
        _name = name;
    }

    public Expression<Func<Person, bool>> ToExpression()
    {
        return p => p.Name.Contains(_name);
    }
}

public class PersonByAgeSpec : ISpecification<Person>
{
    private readonly int _age;

    public PersonByAgeSpec(int age)
    {
        _age = age;
    }

    public Expression<Func<Person, bool>> ToExpression()
    {
        return p => p.Age == _age;
    }
}
```

Now we have specification. Let's change our IPersonRepository


```csharp
public interface IPersonRepository
{
    IEnumerable<Person> GetBySpecification(ISpecification<Person> specification);
}

public class PersonRepository : IPersonRepository
{
    private readonly EFDbContext _context;

    public PersonRepository(EFDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Person> GetBySpecification(ISpecification<Person> specification)
    {
        return _context.Persons.Where(specification.ToExpression());
    }
}
```

Excellent! But how do we search by name and age?
```csharp
//Search by name
var specification = new PersonByNameSpec("Anton");
_personRepository.GetBySpecification(specification);

//Search by name or age
var specification = new PersonByNameSpec("Anton").Or(new PersonByAgeSpec(20));
_personRepository.GetBySpecification(specification);

//Search by name and age
var specification = new PersonByNameSpec("Anton").And(new PersonByAgeSpec(20));
_personRepository.GetBySpecification(specification);
```
Thus, you can connect and combine specifications as much as you like. At the moment, you can connect filters using AND (&&), OR (||), NOT (!), wrap filters in brackets, add a Not condition to filters
If you need to organize filtering using these specifications, then I advise you to take a closer look at this project - https://github.com/Antanidoss/Antanidoss.Specification.Filters

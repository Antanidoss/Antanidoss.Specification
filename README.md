## Give a Star! :star:

If you like or are using this project please give it a star. Thanks!

# Install

Current version of nuget package - https://www.nuget.org/packages/QueryableFilterSpecification/

The framework is provided as a set of NuGet packages.

To install the minimum requirements:

```
Install-Package QueryableFilterSpecification
```

## Usage

This project is needed to facilitate the use of filters on large projects.
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
public class PersonByNameFilterSpec : IQueryableFilterSpec<Person>
{
    private readonly string _name;

    public PersonByNameFilterSpec(string name)
    {
        _name = name;
    }

    public IQueryable<Person> ApplyFilter(IQueryable<Person> persons)
    {
        return persons.Where(ToExpression());
    }

    public Expression<Func<Person, bool>> ToExpression()
    {
        return p => p.Name.Contains(_name);
    }
}

public class PersonByAgeFilterSpec : IQueryableFilterSpec<Person>
{
    private readonly int _age;

    public PersonByAgeFilterSpec(int age)
    {
        _age = age;
    }

    public IQueryable<Person> ApplyFilter(IQueryable<Person> persons)
    {
        return persons.Where(ToExpression());
    }

    public Expression<Func<Person, bool>> ToExpression()
    {
        return p => p.Age == _age;
    }
}
```

Now we have specification filters. Let's change our IPersonRepository


```csharp
public interface IPersonRepository
{
    IEnumerable<Person> GetFilter(IQueryableFilterSpec<Person> filter);
}

public class PersonRepository : IPersonRepository
{
    private readonly EFDbContext _context;

    public PersonRepository(EFDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Person> GetFilter(IQueryableFilterSpec<Person> filter)
    {
        return filter.ApplyFilter(_context.Persons);
    }
}
```

Excellent! But how do we search by name and age?
```csharp
//Search by name
var filterByName = new PersonByNameFilterSpec("Anton");
_personRepository.GetFilter(filterByName);

//Search by name or age
var filterByNameOrAge = new PersonByNameFilterSpec("Anton").Or(new PersonByAgeFilterSpec(20));
_personRepository.GetFilter(filterByNameOrAge);

//Search by name and age
var filterByNameAndAge = new PersonByNameFilterSpec("Anton").And(new PersonByAgeFilterSpec(20));
_personRepository.GetFilter(filterByNameAndAge);
```
Thus, you can connect and combine filters as much as you like. At the moment, you can connect filters using AND, Or, wrap filters in brackets, add a Not condition to filters

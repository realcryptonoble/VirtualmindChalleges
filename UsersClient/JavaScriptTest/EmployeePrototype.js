function employee(firstName, lastName, salary) {
    this.firstName = firstName;
    this.lastName = lastName;
    this.salary = salary;
}

employee.prototype.IncreaseSalary = function () {
    this.salary = this.salary + 1000;
};

employee.prototype.ShowDetails = function () {
    console.log("First name: " + this.firstName);
    console.log("Last name: " + this.lastName);
    console.log("Salary: " + this.salary);
};


CREATE TABLE PERSON_TYPE (
	person_role_id int primary key,
	person_role varchar(10)
);

INSERT INTO PERSON_TYPE VALUES /*map type person value with corresponding role.*/
(1, 'employee'),(2,'patient');
/*
* This is the general person
*/
CREATE TABLE PERSON (
	person_id int not null AUTO_INCREMENT primary key,
	-- every person type must exist in out person type table
	person_role_id int, 
	first_name varchar(20) not null,
	last_name varchar(20) not null,
	gender char,
	DOB date not null,
	phone varchar(13),
	email varchar(30) not null unique,
	address varchar(100) not null,
    
	foreign key (person_role_id) references person_type(person_role_id),
	constraint validGender check (gender = 'M' or gender = 'F'),
	constraint unique_person unique(person_id, person_role_id)
);

/*
* This keeps track of the patients.
*/
CREATE TABLE PATIENT(
	patient_id int primary key,
	person_role_id int default 2, -- patient type id = 2
	
	-- we could also take in things like Blood type, blood group etc
	height_inches float(24),
	weight_Pounds float(24),

	-- employee is a person, soo employee id references the person id above
	constraint valid_id foreign key (patient_id) references PERSON(person_id) 
    ON DELETE CASCADE ON UPDATE CASCADE,
    constraint valid_type foreign key (person_role_id) references PERSON_TYPE(person_role_id)
    ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE EMPLOYEE_TYPE(
	employee_role_id int primary key,
	employee_role varchar(30)
);

INSERT INTO EMPLOYEE_TYPE VALUES -- map type employee value with corresponding employee role.
(1, 'doctor'),(2,'nurse'), (3,'receptionist'), (4, 'admin');
/*
* Table holds values general to all staff
* primary key is the staff_ID
* hiredate has to be greater than date of birth.
*/
CREATE TABLE EMPLOYEE (
	employee_id int primary key,
	person_role_id int default 1, -- employee type ID = 1
	employee_role_id int,
	
	hire_date date not null,
	salary int,
	-- employee is a person, soo employee id references the person id above
	constraint valid_person foreign key (employee_id) references PERSON(person_id)
    ON DELETE CASCADE ON UPDATE CASCADE,
    constraint valid_person_type foreign key (person_role_id) references PERSON_TYPE (person_role_id),
    
    constraint valid_employee foreign key(employee_role_id) references EMPLOYEE_TYPE(employee_role_id),
	-- constraint valid_Date CHECK(hire_date > (select DOB from PERSON where person_id = employee_id)),--hiredate > birthdate
	constraint unique_employee unique(employee_id, employee_role_id)
);

CREATE TABLE NURSE (
	nurse_id int primary key,
	employee_role_id int default 2,
	qualification varchar(30),

	constraint valid_person_nurse foreign key (nurse_id) references EMPLOYEE(employee_id)
    ON DELETE CASCADE ON UPDATE CASCADE,
    
    constraint valid_employee_type foreign key (employee_role_id) references EMPLOYEE_TYPE(employee_role_id) 
);

CREATE TABLE DOCTOR (
	doctor_id int primary key,
	employee_role_id int default 1, -- default doctor role id = 1
	the_position varchar(30) not null,

	constraint valid_doc check (position ='trainee' or position='permanent' or position='visiting'),
	constraint valid_person_doc foreign key (doctor_id) references EMPLOYEE(employee_id) ON DELETE CASCADE ON UPDATE CASCADE,
    
    constraint valid_employee_doc foreign key (employee_role_id) references EMPLOYEE_TYPE(employee_role_id) 
);

CREATE TABLE RECEPTIONIST (
	receptionist_id int primary key,
	employee_role_id int default 3,

	constraint valid_person_recep foreign key (receptionist_id) references EMPLOYEE(employee_id) 
    ON DELETE CASCADE ON UPDATE CASCADE,
    
    constraint valid_employee_recep foreign key (employee_role_id) references EMPLOYEE_TYPE(employee_role_id)
);

CREATE TABLE ADMIN (
	admin_id int primary key,
	employee_role_id int default 4,
	
	constraint two_admins_only check (count(*) < 2),
    
	constraint valid_person_admin foreign key (admin_id) references EMPLOYEE(employee_id)
    ON DELETE CASCADE ON UPDATE CASCADE,
    
    constraint valid_employee_admin foreign key (employee_role_id) references EMPLOYEE_TYPE(employee_role_id) 
);

/*
* When the Admin adds a user, he adds the user's email to this table.
*/
CREATE TABLE LOGIN_INFO (
	employee_id int,-- references EMPLOYEE(employee_id) ON DELETE CASCADE ON UPDATE CASCADE,
	email varchar(30),
	the_password varchar(10),		
	
	primary key (email),
	foreign key (employee_id) references EMPLOYEE(employee_id) ON DELETE CASCADE ON UPDATE CASCADE,	
    foreign key (email) references PERSON(email)
);

CREATE TABLE ADDRESS(
	person_id int,
    city varchar(15) not null, 
    state varchar(15) not null,
    
	primary key (person_id),
    foreign key (person_id) references PERSON(person_id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE PAYMENT_INFO (
	patient_id int,
	insurance_id int,
	credit_card varchar(15),
	
	primary key (patient_id),
    foreign key (patient_id) references PATIENT(patient_id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE PATIENT_RECORD(
	patient_id int, 
	date_admitted Date not null,
	doc_diagnosis varchar(100),
	medication varchar(100),
	ammount_charged float(24),

	nurse_visited_id int references NURSE(nurse_id) ON DELETE set null ON UPDATE CASCADE,
	doctor_visited_id int references DOCTOR(doctor_id) ON DELETE set null ON UPDATE CASCADE,
    room_assigned int references ROOM (room_number) ON DELETE SET NULL on update Cascade,

	primary key(patient_id, date_admitted),
    foreign key( patient_id) references PATIENT(patient_id)
);

CREATE TABLE ROOM (
	room_number int not null AUTO_INCREMENT,
	facilities varchar(1000),
	num_of_beds int default 1,
	
	patient_id int unique, 
	primary key(room_number),

    foreign key (patient_id) references PATIENT(patient_id) ON DELETE SET NULL ON UPDATE CASCADE
);









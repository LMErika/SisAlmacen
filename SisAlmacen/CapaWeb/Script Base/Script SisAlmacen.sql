create database SisAlmacen
go

use SisAlmacen
go

create table Usuario(
idUsuario int not null primary key identity(1,1),
Nombre varchar(50) not null,
ApellidoPaterno varchar(50) not null,
ApellidoMaterno varchar(50) not null,
dni char(10) not null,
Usuario varchar(20) not null,
Contasena varchar(20) not null,
Fechanacimiento date,
Direccion varchar(50),
Email varchar(50),
fotografia varchar(20)
)

create table Parametro(
idParametro int not null primary key identity(1,1),
Codigo varchar(20) not null,
Descripcion varchar(40)not null
)

create table DetalleParametro(
idDetallepmt int not null primary key identity(1,1),
Descripcion varchar(30) not null,
idParametro int not null,
estado bit,
foreign key(idParametro) references Parametro(idParametro)
)

create table Producto(
idProducto int not null primary key identity(1,1),
Nombre varchar(50) not null,
Precio decimal(10,2) not null,
Stock int not null,
Serie varchar(20) not null,
Descripcion varchar(50),
Imagen varchar(45),
idDetallepmt int not null,
estado bit,
foreign key(idDetallepmt) references DetalleParametro(idDetallepmt)
)

create table Distribuidor(
idDistribuidor int not null primary key identity(1,1),
RazonSocial varchar(50) not null,
Ruc varchar(50) not null,
Direccion varchar(50) not null,
Telefono char(10),
Email varchar(50),
estado bit
)

create table GuiaRecepcion(
idGuiaRec int not null primary key identity(1,1),
FechaEntrada date not null,
observacion varchar(100),
idUsuario int not null,
foreign key(idUsuario)references Usuario(idUsuario)
)

create table DetalleGuiaRecepcion(
idDetalleGuiRec int not null primary key identity(1,1),
Cantidad int not null,
idGuiaRec int not null,
idProducto int not null,
foreign key(idGuiaRec) references GuiaRecepcion(idGuiaRec),
foreign key(idProducto) references Producto(idProducto)
)

create table GuiaRemision(
idGuiaRemi int not null primary key identity(1,1),
Codigo varchar(20) not null,
Llegada varchar(50) not null,
Salida varchar(50) not null,
Transportista varchar(50),
Total decimal(10,2),
idUsuario int not null,
idDistribuidor int not null,
foreign key(idUsuario) references Usuario(idUsuario),
foreign key(idDistribuidor) references Distribuidor(idDistribuidor)
)

create table DetelleSalida(
idDetalleSal int not null primary key identity(1,1),
precio decimal(10,2) not null,
Cantidad int not null,
Subtotal decimal(10,2),
IGV decimal(10,2), 
idGuiaRemi int not null,
idProducto int not null,
foreign key(idGuiaRemi) references GuiaRemision(idGuiaRemi),
foreign key(idProducto) references Producto(idProducto)
)

create procedure spVerificarAcceso
@prmstrUsuario varchar(20),
@prmstrContasena varchar(20)
as
	select idUsuario,Nombre,ApellidoPaterno,ApellidoMaterno,
	dni,Usuario,Contasena,FechaNacimiento,Direccion,Email,fotografia
	from Usuario where Usuario = @prmstrUsuario and Contasena = @prmstrContasena

create procedure insertarParametro
@codigo varchar(20),
@descripcion varchar(40)
as

insert into Parametro(Codigo,Descripcion)
values(@codigo,@descripcion)

create procedure buscarParametro
@idparametro int
as
	select idParametro,Codigo,Descripcion
	from Parametro
	where idParametro = @idparametro 

create procedure ListarParametro
as
	select idParametro,Codigo,Descripcion
	from Parametro
	order by Codigo

create procedure editarParametro
@codigo varchar(20),
@descripcion varchar(40),
@idParametro int
as
	update Parametro set 
	Codigo = @codigo, 
	Descripcion = @descripcion
	where idParametro = @idParametro
	
create procedure eliminarParametro
@idParametro int
as
	delete from Parametro where idParametro = @idParametro 

/*Procedimientos Detalle Parametro*/

create procedure ListarDetalleParametro
as
	select d.idDetallepmt,d.Descripcion,d.estado,p.idParametro,p.Descripcion as 'Parametro'
	from DetalleParametro d
	inner join Parametro p on(d.idParametro = p.idParametro)
	where d.estado = 1

create procedure InsertarDetalleParametro
@descripcion varchar(30),
@idParametro int
as
	insert into DetalleParametro(Descripcion,idParametro,estado)
	values(@descripcion,@idParametro,1)

create procedure BuscarDetalleParametro
@idDetalle int
as
	select d.idDetallepmt,d.Descripcion,d.estado,p.idParametro,p.Descripcion as 'Parametro'
	from DetalleParametro d
	inner join Parametro p on(d.idParametro = p.idParametro)
	where d.idDetallepmt = @idDetalle

create procedure editarDetalleParametro
@descripcion varchar(30),
@estado bit,
@idDetalle int
as
	update DetalleParametro
	set 
	Descripcion = @descripcion,
	estado = @estado
	where idDetallepmt = @idDetalle


create procedure eliminarDetalleParametro
@estado bit,
@idDetalle int
as
	update DetalleParametro
	set
	estado = @estado
	where idDetallepmt = @idDetalle


/*Procedimientos Distribuidor*/

create procedure ListarDistribuidor
as	
	select idDistribuidor,RazonSocial,Ruc,Direccion,Telefono,Email,estado
	from Distribuidor where estado = 1 

create procedure InsertarDistribuidor
@RazonSocial varchar(50),
@Ruc varchar(50),
@Direccion varchar(50),
@Telefono char(10),
@Email varchar(50)
as
	insert into Distribuidor(RazonSocial,Ruc,Direccion,Telefono,Email,estado)
	values(@RazonSocial,@Ruc,@Direccion,@Telefono,@Email,1)

create procedure BuscarDistribuidor
@idDistribuidor int
as
	select idDistribuidor,RazonSocial,Ruc,Direccion,Telefono,Email,estado
	from Distribuidor where idDistribuidor = @idDistribuidor


create procedure EditarDistribuidor
@RazonSocial varchar(50),
@Ruc varchar(50),
@Direccion varchar(50),
@Telefono char(10),
@Email varchar(50),
@estado bit,
@idDistribuidor int
as
	update Distribuidor
	set
	RazonSocial = @RazonSocial,
	Ruc = @Ruc,
	Direccion = @Direccion,
	Telefono = @Telefono,
	Email = @Email,
	estado = @estado
	where idDistribuidor = @idDistribuidor


create procedure EliminarDistribuidor
@estado bit,
@idDistribuidor int
as
	update Distribuidor
	set
	estado = @estado
	where idDistribuidor = @idDistribuidor
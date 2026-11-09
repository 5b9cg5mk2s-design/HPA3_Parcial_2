# Parcial #2 - Sistema de Autenticación Segura con Arquitectura por Capas

**Fecha:** 28/09/2026

## Asignatura

**Herramientas de Programación Aplicadas III (.NET)**

---

## Contenido del Repositorio

Este proyecto corresponde al desarrollo del **Parcial #2**, cuyo objetivo fue implementar un sistema de autenticación de usuarios utilizando una arquitectura multicapa y aplicando principios de seguridad, validación de información y separación de responsabilidades.

La aplicación permite a los usuarios iniciar sesión mediante credenciales almacenadas en una base de datos MySQL, validando la información mediante procedimientos almacenados y mostrando una interfaz principal una vez completada la autenticación.

Además, se aplican conceptos fundamentales como:

- Arquitectura por capas.
- Patrón MVP (Model View Presenter).
- Programación Orientada a Objetos.
- Interfaces.
- Procedimientos almacenados.
- Validación de datos.
- Seguridad básica en formularios de autenticación.
- Separación de responsabilidades.
- Principio de abstracción.

---

# Arquitectura del Proyecto

El proyecto se encuentra organizado en cuatro capas principales:

## Capa de Datos

Responsable de la comunicación directa con la base de datos MySQL.

### Archivos

```text
D_conexion.cs
D_Usuarios.cs
```

### Responsabilidades

- Gestionar conexiones a MySQL.
- Ejecutar procedimientos almacenados.
- Consultar usuarios.
- Retornar la información a la capa de negocios.

---

## Capa de Entidades

Contiene las clases que representan los objetos del negocio.

### Archivo

```text
E_Usuario.cs
```

### Responsabilidades

- Modelar la información del usuario.
- Transportar datos entre capas.
- Mantener la estructura de los registros obtenidos desde la base de datos.

---

## Capa de Negocios

Contiene la lógica de negocio y las interfaces utilizadas por la aplicación.

### Archivos

```text
N_Usuario.cs
IHashService.cs
IVerificarHashService.cs
```

### Responsabilidades

- Gestionar la lógica de autenticación.
- Aplicar abstracción mediante interfaces.
- Servir como intermediario entre la presentación y los datos.

---

## Capa de Presentación

Implementa toda la interacción con el usuario.

### Archivos

```text
frmLogin.cs
frmPrincipal.cs
ILoginView.cs
LoginPresenter.cs
Program.cs
```

### Responsabilidades

- Mostrar formularios.
- Capturar datos.
- Mostrar mensajes al usuario.
- Gestionar la navegación entre pantallas.

---

# Funcionalidades Implementadas

## Inicio de Sesión

El sistema permite autenticar usuarios almacenados en una base de datos MySQL.

### Proceso General

1. El usuario introduce sus credenciales.
2. Se validan los datos ingresados.
3. La información es enviada a la capa de negocio.
4. La capa de negocio consulta la capa de datos.
5. Se ejecuta un procedimiento almacenado.
6. Si las credenciales son válidas, se muestra el formulario principal.
7. Si son incorrectas, se muestra un mensaje de error.

---

# Formulario de Login

## Descripción

La ventana de inicio de sesión constituye el punto de entrada principal del sistema.

### Características

- Campo de usuario.
- Campo de contraseña.
- Ocultamiento de contraseña.
- Validaciones previas.
- Control de errores.
- Integración con el Presenter.

---

## Protección de Contraseñas

Se utiliza:

```csharp
txtPassword.UseSystemPasswordChar = true;
```

Esto evita que la contraseña sea visible durante su escritura.

---

# Validaciones Implementadas

Antes de realizar el intento de autenticación se ejecutan varias verificaciones.

## Campos Obligatorios

Se verifica que:

```text
Usuario ≠ vacío
Contraseña ≠ vacía
```

No se permiten cadenas vacías ni espacios en blanco.

---

## Validación de Caracteres

El sistema restringe los caracteres permitidos en el nombre de usuario.

Expresión utilizada:

```csharp
^[a-zA-Z0-9_]+$
```

Permite:

```text
Letras
Números
Guiones bajos (_)
```

Evita:

```text
Caracteres especiales
Inyecciones básicas
Entradas maliciosas
```

---

## Longitud de Contraseña

Se valida que la contraseña posea al menos:

```text
4 caracteres
```

---

# Prevención de SQL Injection

Como medida de seguridad:

- Se validan los caracteres de entrada.
- Se utilizan procedimientos almacenados.
- No se construyen consultas SQL mediante concatenación en la interfaz.

Esto ayuda a reducir riesgos relacionados con:

```text
SQL Injection
Consultas maliciosas
Manipulación de credenciales
```

---

# Uso de Procedimientos Almacenados

La autenticación se ejecuta mediante:

```sql
sp_ValidarLoginHash
```

Este procedimiento es invocado desde la capa de datos.

Ejemplo:

```csharp
cmd.CommandType = CommandType.StoredProcedure;
```

Beneficios:

- Mayor seguridad.
- Centralización de la lógica.
- Menor exposición de consultas SQL.
- Mejor mantenimiento.

---

# Patrón MVP (Model View Presenter)

El proyecto implementa el patrón MVP para desacoplar la interfaz gráfica de la lógica de negocio.

## Componentes

### View

Representada por:

```text
frmLogin
```

Implementa:

```csharp
ILoginView
```

Su función es:

- Mostrar información.
- Obtener datos del usuario.

---

### Presenter

Representado por:

```text
LoginPresenter
```

Responsabilidades:

- Realizar validaciones.
- Coordinar la autenticación.
- Comunicar la vista con la lógica de negocio.

---

### Model

Representado por:

```text
E_Usuario
```

Contiene la información del usuario autenticado.

---

# Gestión de Sesión

Cuando el login es exitoso:

```csharp
frmPrincipal principalForm =
new frmPrincipal(usuario);
```

El formulario principal recibe la información del usuario autenticado.

---

# Formulario Principal

## Descripción

Es la pantalla principal del sistema una vez iniciada la sesión.

### Funcionalidades

- Mostrar usuario conectado.
- Mostrar fecha actual.
- Mostrar hora actual.
- Actualización automática mediante Timer.
- Acceso a módulos del sistema.

---

## Información de Sesión

El sistema muestra:

```text
Usuario conectado
Estado de conexión
```

Ejemplo:

```text
Usuario: administrador
Conectado
```

---

## Reloj Digital

Mediante un componente Timer se actualiza continuamente:

```text
Hora
Fecha
```

Mostrando información en tiempo real dentro del formulario.

---

# Interfaces Utilizadas

## ILoginView

Define el contrato que debe cumplir cualquier vista de autenticación.

Métodos:

```csharp
MostrarMensajeExitoso()
MostrarMensajeError()
OcultarVista()
```

---

## IHashService

Responsable de definir el contrato para la generación de hashes.

Método:

```csharp
GenerarHash()
```

---

## IVerificarHashService

Responsable de definir la verificación de hashes.

Método:

```csharp
Verificar()
```

---

# Programación Orientada a Objetos Aplicada

## Encapsulación

Se implementa mediante propiedades en:

```csharp
E_Usuario
```

---

## Abstracción

Se implementa mediante:

```csharp
ILoginView
IHashService
IVerificarHashService
```

---

## Polimorfismo

La clase:

```csharp
frmLogin
```

trabaja utilizando la abstracción:

```csharp
ILoginView
```

en lugar de depender directamente de una implementación concreta.

---

## Separación de Responsabilidades

Cada capa tiene funciones específicas:

| Capa | Responsabilidad |
|--------|----------------|
| Datos | Acceso a MySQL |
| Entidades | Transporte de información |
| Negocios | Reglas de negocio |
| Presentación | Interfaz con el usuario |

---

# Seguridad Implementada

Entre las medidas de seguridad aplicadas se encuentran:

- Ocultamiento de contraseñas.
- Validación de entradas.
- Restricción de caracteres.
- Uso de procedimientos almacenados.
- Separación de capas.
- Manejo controlado de errores.
- Prevención básica de SQL Injection.

---

# Capturas de Pantalla

## Pantalla de Login

<img width="619" height="411" alt="image" src="https://github.com/user-attachments/assets/03e0b4f1-e7d4-4527-8a0e-bf71958b23bb" />


## Validaciones del Sistema

<img width="616" height="407" alt="image" src="https://github.com/user-attachments/assets/553f6e8f-8f91-41c5-b841-2d63d27d7b10" />


## Inicio de Sesión Correcto

<img width="822" height="413" alt="image" src="https://github.com/user-attachments/assets/7bf4d270-0ea4-46d6-80e2-4e9310c425e6" />


## Formulario Principal

<img width="751" height="509" alt="image" src="https://github.com/user-attachments/assets/8ad30650-6868-4b1e-ae89-5e76521edbaa" />


---

# Estructura del Proyecto

```plaintext
Parcial2/
│
├── Datos/
│   ├── D_conexion.cs
│   └── D_Usuarios.cs
│
├── Entidades/
│   └── E_Usuario.cs
│
├── Negocios/
│   ├── N_Usuario.cs
│   ├── IHashService.cs
│   └── IVerificarHashService.cs
│
├── Presentacion/
│   ├── frmLogin.cs
│   ├── frmPrincipal.cs
│   ├── ILoginView.cs
│   ├── LoginPresenter.cs
│   └── Program.cs
│
├── images/
│   ├── login.png
│   ├── validaciones-login.png
│   ├── login-exitoso.png
│   └── formulario-principal.png
│
└── README.md
```

---

# Requisitos del Sistema

## Software

- Visual Studio 2022 o superior
- .NET Framework
- MySQL Server
- MySQL Connector/NET

---

## Base de Datos

Base de datos utilizada:

```text
productosdb
```

Cadena de conexión:

```csharp
Server=localhost;
Database=productosdb;
Uid=root;
Pwd=;
```

---

# Instrucciones de Ejecución

## 1. Clonar el repositorio

```bash
git clone [URL_DEL_REPOSITORIO]
```

## 2. Configurar MySQL

Crear la base de datos:

```sql
CREATE DATABASE productosdb;
```

## 3. Crear los procedimientos almacenados

Importar los scripts SQL proporcionados.

## 4. Configurar la conexión

Modificar:

```csharp
D_conexion.cs
```

según las credenciales locales.

## 5. Abrir el proyecto

Abrir la solución en Visual Studio.

## 6. Compilar

```text
Build > Build Solution
```

## 7. Ejecutar

```text
F5
```

---

# Aprendizajes Obtenidos

Durante el desarrollo de este parcial se reforzaron conocimientos sobre:

- Arquitectura multicapa.
- Programación Orientada a Objetos.
- Interfaces.
- Patrón MVP.
- Procedimientos almacenados.
- Conexiones MySQL.
- Validación de datos.
- Seguridad en autenticación.
- Manejo de sesiones.
- Desarrollo de aplicaciones empresariales en Windows Forms.

---

# Autor y Contexto

- Nombre: Johandry González
- Asignatura: Herramientas de Programación Aplicadas III (.NET)
- Evaluación: Parcial #2
- Fecha: 28/09/2026

---

# Referencias
- Material proporcionado por el docente

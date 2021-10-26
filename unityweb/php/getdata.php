<?php
if(isset($_POST["nombre"]) ){
  include'config.php';

$name=$_POST["nombre"];

$conn = new mysqli($servername, $username, $password,$dbname);
  if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
  }

$sql2 = "SELECT id FROM `users` WHERE USER='$name'";
    
    $result = $conn->query($sql2);

if ($result->num_rows > 0) {
  // output data of each row
  
  while($row = $result->fetch_assoc()) {
       echo  $row["id"];
  }
  
  $conn->close();
}
}
?>
<?php
if(isset($_POST["id"]) ){
  include'config.php';

$name=$_POST["id"];

$conn = new mysqli($servername, $username, $password,$dbname);
  if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
  }

$sql2 = "SELECT * FROM `users` WHERE ID='$name'";
    
    $result = $conn->query($sql2);

if ($result->num_rows > 0) {
  // output data of each row
  $answer;
  while($row = $result->fetch_assoc()) {
      $answer= $row;
    /*$answer ->name = $row[0];
    $answer ->id = $row[1];
    $answer ->grabhammer = $row[2];
    $answer ->helmet = $row[3];
    $answer ->timeend = $row[4];*/
  }
  $answer=json_encode($answer);
  echo $answer;
  $conn->close();
}
}
?>
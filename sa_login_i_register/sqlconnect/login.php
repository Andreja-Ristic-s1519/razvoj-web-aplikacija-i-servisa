<?php

$con = mysqli_connect('localhost', 'root', '', 'zmija');

if (mysqli_connect_errno()){
    echo "1";
    exit();
}

$username = $_POST["name"];
$password = $_POST["password"];

$namecheckquerry = "SELECT username, password, highscore FROM korisnici WHERE username = '" . $username . "';";
   
$namecheck = mysqli_query($con, $namecheckquerry) or die("2");

if (mysqli_num_rows($namecheck) != 1)
{
    echo "5";
    exit();
}
$info = mysqli_fetch_assoc($namecheck);
$pass = $info['password'];

if($password != $pass)
{
    echo "6";
    exit();
}

echo "0\t" . $info["highscore"];


?>
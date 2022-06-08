<?php 

$con = mysqli_connect('localhost', 'root', '', 'zmija');

if (mysqli_connect_errno()){
    echo "1";
    exit();
}


$username = $_POST["name"];
$newscore = $_POST["score"];

$namecheckquerry = "SELECT username FROM korisnici WHERE username = '" . $username . "';";

$namecheck = mysqli_query($con, $namecheckquerry) or die ("2");

if (mysqli_num_rows($namecheck) != 1)
{
    echo "5";
    exit();
}

$updatequery = "UPDATE korisnici SET highscore = " .$newscore . " WHERE username = '".$username."';";
mysqli_query($con, $updatequery) or die ("7");

echo "0";


?>
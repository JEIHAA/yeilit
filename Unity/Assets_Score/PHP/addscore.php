<?php

$servername = "localhost";
$username = "root";
$password = "pass1234";
$dbname = "db_score";

$id = $_POST["id"];
$score = $_POST["score"];

$conn = new mysqli($servername, $username, $password, $dbname);

if($conn->connect_error) {
	die ("connection failed: " . $conn->connect_error);
}

$sql = "SELECT * FROM tb_score WHERE id = '" . $id . "'";
$result = $conn->query($sql);

if($result->num_rows > 0) {
	$update_sql = "UPDATE tb_score SET score = '" . $score . "' WHERE id = '" . $id . "'";
	$conn->query($update_sql);
}
else {
	$insert_sql = "INSERT INTO tb_score (id, score)
				   VALUES ('" . $id . "', '" . $score . "')";
	$conn->query($insert_sql);
}

$conn->close();

?>
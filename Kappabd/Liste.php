<!DOCTYPE html>
<html>
<head>
<link rel="stylesheet" type="text/css" href="FormStyles.css">

</head>
<body class="Background">

		<ul id='couleur'>
  <li><a  href="index.php">Home</a></li>
  <li><a  href="liste.php">News</a></li>
  <li><a  href="#contact">Contact</a></li>
  <li style="float:right"><a  href="Connexion.php">Connexion</a></li>
  </ul>

 <?php
			try
			{
				$bdd = new PDO('mysql:host=localhost;dbname=Kappabd;charset=utf8', 'Kappa', 'Kappa');
			    
			   }
			 
			   catch (PDOException $e)
			{
			       echo('Erreur de connexion: ' . $e->getMessage());
			       
			       exit();
			        
			} 
			
			
				try
				{
					$bdd = new PDO('mysql:host=localhost;dbname=Kappabd;charset=utf8', 'Kappa', 'Kappa');
				  	$stm = $bdd ->prepare("CALL ListerSpectacle()", array(PDO::ATTR_CURSOR, PDO::CURSOR_FWDONLY));

					// appel de la procÃ©dure stockÃ©e
					$stm->execute();
					
					$rows = 10; // amout of tr 
					$cols = 10;// amjount of td 
					
					echo "<table>
						  <tr>
						  <th>Date</th>
						  <th>Heure</th>
						    <th>Categorie</th>
						    <th>Salle</th>
						    <th>Artiste</th>
						    <th>Que faire</th>
						  </tr>"; 

						 while ($donnees = $stm->fetch())
					    {
					    	echo "<tr>
					    			<td>$donnees[1]</td>
									<td>$donnees[2]</td>
								    <td>$donnees[3]</td>
								    <td>$donnees[4]</td>
								    <td>$donnees[5]</td>
								    <td><ul>
										    <li><a>ajouter</a></li>
										    <li><a>modifier</a></li>
										    <li><a>supprimer</a></li>
										</ul>								  
								   </td>
								</tr>";
					    						    	
					    					   											   						
						}

					   	echo "</table>";				    

					

					


				$stm->closeCursor();
					
				 }
				 
				 catch (PDOException $e)
				{
				       echo('chouuuu');
				       
				       exit();
				        
				} 

				
								
			

			  
		 ?>	


</body>
</html>

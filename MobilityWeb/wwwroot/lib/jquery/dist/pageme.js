$(document).ready(function() {
    $('.showbuttontables').click(function(event) {
        event.preventDefault(); 
        
        $('#showbuttons').toggle(); // Toggle
        
        
        //search event 
        $('#searchLink').click(function() {
            // Get the value from the input field
            const nameValue = $('#searchInput').val();
            // Set the value to the asp-route-name attribute of the anchor tag
            $('#searchLink').attr('asp-route-id',nameValue).attr('href','Customer/SearchView?id='+nameValue)
        });

        //search event 
        $('#deletebutton').click(function() {
            // Get the value from the input field
            const nameIdValue = $('#customerNameId').val();
           
            // Set the value to the asp-route-name attribute of the anchor tag
            $('#deletebutton').attr('asp-route-id',nameIdValue).attr('href','Customer/Delete?id='+nameIdValue)
           
        });

         
    });
});
  
read -p "Enter module name: " MODULE_NAME
ng g module --routing ${MODULE_NAME}
cd ${MODULE_NAME}
mkdir views
mkdir service
mkdir data
mkdir components
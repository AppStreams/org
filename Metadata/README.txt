1. Create reusable schema in /metadata/models.

The HTML pages for Models and Events need to be created by hand to provide an overview of the schema - these are placed in /models/ (e.g. /models/Waste/Material)

The APIs themselves are automatically generated as explained below.

2. Create your API definition in the appropriate location - e.g. /metadata/services/Waste/Service/openapi.json
In this file, you can resuse the schema definitions in the /metadata/models folder.

3. Generate the documentation:

    To generate documentation, we use Swagger Codegen.

    This is installed as :

    brew install swagger-codegen

    It can be run as:

    cd $root
    cd Metadata
    swagger-codegen generate -i Services/Waste/Service/openapi.json -l html2 -o ../wwwroot/metadata/services/waste/service

4. Embed in the services Html page at "/Services" using the generated metadata path (local or remote).


=====


The metadata is a collection of files that allow you to define the data for AppStreams using metadata such that
it can be defined anywhere on the web or in any backend and hence presented on any website or application in full
or in part.

https://swagger.io/tools/swagger-editor/

[
    {
        "id": "http://appstreams.org/service/Waste/Collection/Schedule",
        "parent": "http://appstreams.org/service/Waste/Collection",
        "type": "http://appstreams.org/service",
        "name": "Bin Schedule",
        "summary": "Gets the bin collection schedule for a postcode",
        "method": "post",
        "params": [
            {
                "name": "country",
                "type": "https://schema.org/Text",
                "required": true,
                "default": "gb"
                
        ]
    }
]



{
  "type": "Model",
}



{
  "type": "Event",
}
function CrystalViewer($)
{
	this.ToolBar;
	this.StatusBar;
	this.Responsive;
	this.Width;
	this.Height;
	this.WebConfig;
	this.Metadata;
	this.Param;
	this.Path;
	this.DataBase;
	this.Conection;

	// Databinding for property WebConfig
	this.SetWebConfig = function(data)
	{
		///UserCodeRegionStart:[SetWebConfig] (do not remove this comment.)
		this.WebConfig = data;
		
		
		///UserCodeRegionEnd: (do not remove this comment.)
	}

	// Databinding for property WebConfig
	this.GetWebConfig = function()
	{
		///UserCodeRegionStart:[GetWebConfig] (do not remove this comment.)
		return this.WebConfig;
		
		
		///UserCodeRegionEnd: (do not remove this comment.)
	}

	// Databinding for property Metadata
	this.SetMetadata = function(data)
	{
		///UserCodeRegionStart:[SetMetadata] (do not remove this comment.)
		this.Metadata = data;
		
		
		///UserCodeRegionEnd: (do not remove this comment.)
	}

	// Databinding for property Metadata
	this.GetMetadata = function()
	{
		///UserCodeRegionStart:[GetMetadata] (do not remove this comment.)
		return this.Metadata;
		
		
		///UserCodeRegionEnd: (do not remove this comment.)
	}

	// Databinding for property Param
	this.SetParam = function(data)
	{
		///UserCodeRegionStart:[SetParam] (do not remove this comment.)
		this.Conection = data;
		
		
		///UserCodeRegionEnd: (do not remove this comment.)
	}

	// Databinding for property Param
	this.GetParam = function()
	{
		///UserCodeRegionStart:[GetParam] (do not remove this comment.)
		return this.Conection;		
		
		
		///UserCodeRegionEnd: (do not remove this comment.)
	}

	// Databinding for property Path
	this.SetPath = function(data)
	{
		///UserCodeRegionStart:[SetPath] (do not remove this comment.)
		this.Path = data;
		
		
		///UserCodeRegionEnd: (do not remove this comment.)
	}

	// Databinding for property Path
	this.GetPath = function()
	{
		///UserCodeRegionStart:[GetPath] (do not remove this comment.)
		return this.Path;
		
		
		///UserCodeRegionEnd: (do not remove this comment.)
	}

	// Databinding for property Conection
	this.SetConection = function(data)
	{
		///UserCodeRegionStart:[SetConection] (do not remove this comment.)


		///UserCodeRegionEnd: (do not remove this comment.)
	}

	// Databinding for property Conection
	this.GetConection = function()
	{
		///UserCodeRegionStart:[GetConection] (do not remove this comment.)


		///UserCodeRegionEnd: (do not remove this comment.)
	}

	this.show = function()
	{
		///UserCodeRegionStart:[show] (do not remove this comment.)

			
		var myContainer  = document.getElementById(this.ContainerName);
		
		_this = this;
			
        var buffer = '';
		
		if (!this.IsPostBack) {				  
			buffer += createHTML();				
			$(myContainer).append(buffer);		
		}			
				
		function createHTML(){										
			
			var h    = [];			
			var html = '';		
			
			console.log(_this.Path);
			console.log(_this.ToolBar);
			console.log(_this.StatusBar);

			h.push('<main role="main">');		
			h.push('<iframe name="Framename" src="./CrystalViewer/Default.aspx?rpt='+_this.Path+'&toolbar='+_this.ToolBar+'&=statusbar='+_this.StatusBar+'" frameborder="0" scrolling="auto" class="frame-area"></iframe>');
			h.push('</main>');	
		
			// Write text
			h.forEach(function (str, index) {
                html += str;
            });
				
			return html;			
		}
		
		
		///UserCodeRegionEnd: (do not remove this comment.)
	}
	///UserCodeRegionStart:[User Functions] (do not remove this comment.)
	
	
	
	
	///UserCodeRegionEnd: (do not remove this comment.):
}

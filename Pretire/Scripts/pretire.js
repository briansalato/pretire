$(function () {
    $("input[mask]").each(function (input) {
        $(this).mask(this.attributes['mask'].value);
    });
});

var Pretire = {

    createPerson : (function() {
        var self = {}
        var salaryGrowthRate
            , contributionTo401k
            , growthOf401kContribution;
        
        self.init = function () {
            //$('#YearlySalary').mask('#,##0.99', { reverse: true });
            salaryGrowthRate = $('#YearlySalaryGrowthRate');
            contributionTo401k = $('#Yearly401kContribution');
            growthOf401kContribution = $('#Yearly401kGrowthRate');

            $('#SalaryGrowthType').change(function () {
                setSalaryGrowthSection(this.options[this.selectedIndex].value);
            })
            .trigger('change');

            $('#TypeOf401k').change(function () {
                set401kSection(this.options[this.selectedIndex].value);
            })
            .trigger('change');

            $('#ContributionTo401kType').change(function () {
                set401kContributionSection(this.options[this.selectedIndex].value);
            })
            .trigger('change');

            $('#Yearly401kGrowthRateType').change(function () {
                set401kGrowthSection(this.options[this.selectedIndex].value);
            })
            .trigger('change');

            $('.non-zero[value=0]').val('');
        };

        var setSalaryGrowthSection = function (growthType) {
            switch (growthType) {
                case '0':
                    salaryGrowthRate.val('');
                    salaryGrowthRate.attr('disabled', 'disabled');
                    break;
                default:
                    salaryGrowthRate.removeAttr('disabled');
                    break;
            }
        };

        var set401kSection = function (typeOf401k) {
            var elements = $('.section-401k input, .section-401k select').not('#TypeOf401k');
            if (typeOf401k != '0') {
                elements.removeAttr('disabled');
                elements.trigger('change');
            } else {
                elements.attr('disabled', 'disabled');
            }
        };

        var set401kContributionSection = function (contributionType) {
            switch (contributionType) {
                case '0':
                    contributionTo401k.val('');
                    contributionTo401k.attr('disabled', 'disabled');
                    break;
                default:
                    contributionTo401k.removeAttr('disabled');
                    break;
            }
        };

        var set401kGrowthSection = function (growthType) {
            switch (growthType) {
                case '0':
                    growthOf401kContribution.val('');
                    growthOf401kContribution.attr('disabled', 'disabled');
                    break;
                default:
                    growthOf401kContribution.removeAttr('disabled');
                    break;
            }

        }

        return self;
    }()),
};